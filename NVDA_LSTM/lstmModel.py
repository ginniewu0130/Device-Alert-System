import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from pandas import read_csv
import time
import math
import tensorflow as tf

from keras.layers.core import Dense, Activation, Dropout
from keras.models import Sequential
from keras.layers import Dense
from keras.layers import LSTM
from sklearn.preprocessing import MinMaxScaler
from sklearn.metrics import mean_squared_error

# 訓練樣本數比例
SPLIT_RATIO = 0.5
# 感知器記憶長度
LOOK_BACK = 240

np.random.seed(5)

nvda_prices = read_csv('NVDA_LSTM/NVDA.csv', index_col=None, delimiter=',')
labels = nvda_prices['close'].values
dataset = labels.reshape(-1, 1)
print(f'資料集 {dataset[:10]} 長度 {len(dataset)}')

#標準化
Scaler = MinMaxScaler(feature_range=(0, 1))
dataset = Scaler.fit_transform(dataset)
split_size = int(len(dataset) * SPLIT_RATIO)
test_size = len(dataset) - split_size

train_dataset = dataset[0:split_size, :]
test_dataset = dataset[split_size:len(dataset), :]

print(f'訓練資料集 {train_dataset[:10]} 長度 {len(train_dataset)}')
print(f'測試資料集 {test_dataset[:10]} 長度 {len(test_dataset)}')

#拆分
def buildDataset(dataset, look_back=1):
    dataX, dataY = [], []
    for i in range(len(dataset) - look_back - 1):
        a = dataset[i:(i + look_back), 0]
        dataX.append(a)
        dataY.append(dataset[i + look_back, 0])
    return np.array(dataX), np.array(dataY)
train_x, train_y = buildDataset(train_dataset, LOOK_BACK)
test_x, test_y = buildDataset(test_dataset, LOOK_BACK)
#重塑
train_x = np.reshape(train_x, (train_x.shape[0], 1, train_x.shape[1]))
test_x = np.reshape(test_x, (test_x.shape[0], 1, test_x.shape[1]))

#建模
Model = Sequential()
Model.add(LSTM(250, input_shape=(1, LOOK_BACK)))
Model.add(Dropout(0.1))
Model.add(Dense(1))
Model.compile(loss='mse', optimizer='adam')
# 調整訓練次數可以提升準度，也可以觀察到過擬合的問題
Model.fit(train_x, train_y, epochs=1000, batch_size=240, verbose=0)

#預測
train_predict = Model.predict(train_x)
test_predict = Model.predict(test_x)

train_predict = Scaler.inverse_transform(train_predict)
train_y = Scaler.inverse_transform([train_y])
test_predict = Scaler.inverse_transform(test_predict)
test_y = Scaler.inverse_transform([test_y])

train_score = math.sqrt(mean_squared_error(train_y[0], train_predict[:,0]))
print(f'訓練誤差分數(RMSE)：{np.round(train_score, 3)}')

test_score = math.sqrt(mean_squared_error(test_y[0], test_predict[:,0]))
print(f'測試誤差分數(RMSE)：{np.round(test_score, 3)}')

train_predict_plot = np.empty_like(dataset)
train_predict_plot[:, :] = np.nan
train_predict_plot[LOOK_BACK:len(train_predict) + LOOK_BACK, :] = train_predict
test_predict_plot = np.empty_like(dataset)
test_predict_plot[:, :] = np.nan
test_predict_plot[len(train_predict) + (LOOK_BACK * 2) + 1:len(dataset)-1, :] = test_predict
plt.figure(figsize=(20, 7))
plt.plot(Scaler.inverse_transform(dataset))

plt.plot(train_predict_plot)
plt.plot(test_predict_plot)
plt.show()

#匯出CSV檔
test_prices=Scaler.inverse_transform(dataset[test_size+LOOK_BACK:])

result = pd.DataFrame(
    data={
        "測試價格": np.around(list(test_prices.reshape(-1)), decimals=2),
        "預測價格": np.around(list(test_predict.reshape(-1)), decimals=2)
    }
)
result.to_csv("股價預測對比.csv", sep=',', index=None)
print(result)
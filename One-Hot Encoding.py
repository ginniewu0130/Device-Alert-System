import csv
import numpy as np
import pandas as pd
from sklearn.preprocessing import OneHotEncoder
from sklearn.preprocessing import LabelEncoder

logs = pd.read_csv('output_2.csv')

maintype=logs['Type']
subtype=logs['Sub-Type']
action=logs['Action']

dic={'Type':maintype,'Sub-Type':subtype,'Action':action}
data=pd.DataFrame(dic)
print(data)


labelencoder = LabelEncoder()
data_le=pd.DataFrame(dic)
data_le['Type'] = labelencoder.fit_transform(data['Type'])
data_le['Sub-Type'] = labelencoder.fit_transform(data['Sub-Type'])
data_le['Action'] = labelencoder.fit_transform(data['Action'])
print(data_le)


onehotencoder = OneHotEncoder(categories='auto')
data_str_ohe=onehotencoder.fit_transform(data_le).toarray()
pd.DataFrame(data_str_ohe)

data_dum = pd.get_dummies(data)
data_dum.replace({True: 1, False: 0}, inplace=True)
pd.DataFrame(data_dum).to_csv('output_4.csv', index=False)


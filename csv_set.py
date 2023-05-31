import re
import csv

log_date = r'date=(\d+\-\d+\-\d+)'
log_time = r'time=(\d+\:\d+\:\d+)'
log_devname = r'devname="([\w-]+)"'
log_devid = r'devid="([\w-]+)"'
log_eventtime = r'eventtime=(\d+)\s'
log_tz = r'tz="(\++\d+)"'
log_logid = r'logid="(\d+)"'
log_type = r'type="(\w+)"'
log_subtype = r'subtype="(\w+)"'
log_eventtype = r'eventtype=""(.+?)"'
log_level = r'level="(\w+)"'
log_vd = r'vd="([\w-]+)"'
log_severity = r'severity="(\w+)"'
log_srcip = r'srcip=(\d+\.\d+\.\d+\.\d+)\s'
log_srcport = r'srcport=(\d+)'
log_srcintf = r'srcintf="([\w-]+)"'
log_srcintfrole = r'srcintfrole="(\w+)"'
log_dstip = r'dstip=(\d+\.\d+\.\d+\.\d+)'
log_dstport = r'dstport=(\d+)'
log_dstintf = r'dstintf="([\w-]+)"'
log_dstintfrole = r'dstintfrole="(\w+)"'
log_srccountry = r'srccountry="(.+?)"'
log_dstcountry = r'dstcountry="(.+?)"'
log_sessionid = r'sessionid=(\d+)'
log_proto = r'proto=(\d+)'
log_action = r'action="([\w-]+)"'
log_policyid = r'policyid=(\d+)'
log_policytype = r'policytype="(\w+)"'
log_poluuid = r'poluuid="([\w-]+)"'
log_service = r'service="(.+?)"'
log_trandisp = r'trandisp="(\w+)"'
log_appcat = r'appcat="(\w+)"'
log_applist = r'applist="([\w-]+)"'
log_duration = r'duration=(\d+)'
log_sentbyte = r'sentbyte=(\d+)'
log_rcvdbyte = r'rcvdbyte=(\d+)'
log_sentpkt = r'sentpkt=(\d+)'
log_rcvdpkt = r'rcvdpkt=(\d+)'
log_direction = r'direction="(\w+)"'
log_attack = r'attack="(.+?)"'
log_attackid = r'attackid=(\d+)'
log_profile = r'profile="(.+?)"'
log_xid = r'xid=(\d+)'
log_qname = r'qname="(.+?)"'
log_qtype = r'qtype="(\w+)"'
log_qtypeval = r'qtypeval=(\d+)'
log_qclass = r'qclass="(\w+)"'
log_error = r'error="(.+?)"'
log_rcode = r'rcode=(\d+)'
log_ref = r'ref="(.+?)"'
log_incidentserialno = r'incidentserialno=(\d+)'
log_msg = r'msg="(.+?)"'
log_crscore = r'crscore=(\d+)'
log_craction = r'craction=(\d+)'
log_crlevel = r'crlevel="(\w+)"'
log_logdesc = r'logdesc="(.+?)"'

with open('firewall.txt', 'r') as f:
    logs = f.readlines()

with open('output.csv', 'w', newline='') as csvfile:
    writer = csv.writer(csvfile)

    writer.writerow(['Month', 'Date', 'Time', 'Device', "Date", "Time", 'Dev Name', 'Dev ID', 'Event Time', 'Time Zone', 'LogID', 'Type', 'Subtype', 'Event Type', 'Level', 'Virtual Domain', 'Severity', 'Src IP', 'Src Port', 'Src Interface', 'Src Interface Role', 'Dst IP', 'Dst Port', 'Dst Interface', 'Dst Interface Role', 'Src Country', 'Dst Country', 'Session ID', 'Proto', 'Action', 'Policy ID', 'Policy type', 'Policy UUID', 'Service', 'Trandisp', 'Application Category', 'Application List', 'Duration', 'Sent Byte', 'Recovered Byte', 'Sent PKT', 'Recovered PKT', 'Direction', 'Attack', 'Attack ID', 'Profile', 'Transaction ID', 'Query Name', 'Query Type', 'Query Type Value', 'Query Class', 'Error', 'Response Code', 'Reference', 'Incidentserialno', 'Message', 'Core Rule Set score', 'Core Rule Action', 'Core Rule Level', 'Log description'])
    
    

    for log in logs:
        month = log[:3]
        date_1 = log[4:6]
        time_1 = log[7:15]
        device = log[16:22]
        match = re.search(log_date, log)
        if match:
            date_2 = match.group(1)
        else:
            date_2 = None
        match = re.search(log_time, log)
        if match:
            time_2 = match.group(1)
        else:
            time_2 = None

        match = re.search(log_devname, log)
        if match:
            devname = match.group(1)
        else:
            devname = None
        match = re.search(log_devid, log)
        if match:
            devid = match.group(1)
        else:
            devid = None
        match = re.search(log_eventtime, log)
        if match:
            eventtime = match.group(1)
        else:
            eventtime = None
        match = re.search(log_tz, log)
        if match:
            tz = "[" + match.group(1) + "]"
        else:
            tz = None
        match = re.search(log_logid, log)
        if match:
            logid = match.group(1)
        else:
            logid = None
        match = re.search(log_type, log)
        if match:
            maintype = match.group(1)
        else:
            maintype = None
        match = re.search(log_subtype, log)
        if match:
            subtype = match.group(1)
        else:
            subtype = None
        match = re.search(log_eventtype, log)
        if match:
            eventtype = match.group(1)
        else:
            eventtype = None
        match = re.search(log_level, log)
        if match:
            if(match.group(1) == "notice"):
                level = 0
            elif(match.group(1) == "warning"):
                level = 1
            elif(match.group(1) == "alert"):
                level = 2
            elif(match.group(1) == "error"):
                level = 3
            elif(match.group(1) == "emergency"):
                level = 4
        else:
            level = None
        match = re.search(log_vd, log)
        if match:
            vd = match.group(1)
        else:
            vd = None
        match = re.search(log_severity, log)
        if match:
            severity = match.group(1)
        else:
            severity = None
        match = re.search(log_srcip, log)
        if match:
            srcip = match.group(1)
        else:
            srcip = None
        match = re.search(log_srcport, log)
        if match:
            srcport = match.group(1)
        else:
            srcport = None
        match = re.search(log_srcintf, log)
        if match:
            srcintf = match.group(1)
        else:
            srcintf = None
        match = re.search(log_srcintfrole, log)
        if match:
            srcintfrole = match.group(1)
        else:
            srcintfrole = None
        match = re.search(log_dstip, log)
        if match:
            dstip = match.group(1)
        else:
            dstip = None
        match = re.search(log_dstport, log)
        if match:
            dstport = match.group(1)
        else:
            dstport = None
        match = re.search(log_dstintf, log)
        if match:
            dstintf = match.group(1)
        else:
            dstintf = None
        match = re.search(log_dstintfrole, log)
        if match:
            dstintfrole = match.group(1)
        else:
            dstintfrole = None
        match = re.search(log_srccountry, log)
        if match:
            srccountry = match.group(1)
        else:
            srccountry = None
        match = re.search(log_dstcountry, log)
        if match:
            dstcountry = match.group(1)
        else:
            dstcountry = None
        match = re.search(log_sessionid, log)
        if match:
            sessionid = match.group(1)
        else:
            sessionid = None
        match = re.search(log_proto, log)
        if match:
            proto = match.group(1)
        else:
            proto = None
        match = re.search(log_action, log)
        if match:
            action = match.group(1)
        else:
            action = None
        match = re.search(log_policyid, log)
        if match:
            policyid = match.group(1)
        else:
            policyid = None
        match = re.search(log_policytype, log)
        if match:
            policytype = match.group(1)
        else:
            policytype = None
        match = re.search(log_poluuid, log)
        if match:
            poluuid = match.group(1)
        else:
            poluuid = None
        match = re.search(log_service, log)
        if match:
            service = match.group(1)
        else:
            service = None
        match = re.search(log_trandisp, log)
        if match:
            trandisp = match.group(1)
        else:
            trandisp = None
        match = re.search(log_appcat, log)
        if match:
            appcat = match.group(1)
        else:
            appcat = None
        match = re.search(log_applist, log)
        if match:
            applist = match.group(1)
        else:
            applist = None
        match = re.search(log_duration, log)
        if match:
            duration = match.group(1)
        else:
            duration = None
        match = re.search(log_sentbyte, log)
        if match:
            sentbyte = match.group(1)
        else:
            sentbyte = None
        match = re.search(log_rcvdbyte, log)
        if match:
            rcvdbyte = match.group(1)
        else:
            rcvdbyte = None
        match = re.search(log_sentpkt, log)
        if match:
            sentpkt = match.group(1)
        else:
            sentpkt = None
        match = re.search(log_rcvdpkt, log)
        if match:
            rcvdpkt = match.group(1)
        else:
            rcvdpkt = None
        match = re.search(log_direction, log)
        if match:
            direction = match.group(1)
        else:
            direction = None
        match = re.search(log_attack, log)
        if match:
            attack = match.group(1)
        else:
            attack = None
        match = re.search(log_attackid, log)
        if match:
            attackid = match.group(1)
        else:
            attackid = None
        match = re.search(log_profile, log)
        if match:
            profile = match.group(1)
        else:
            profile = None
        match = re.search(log_xid, log)
        if match:
            xid = match.group(1)
        else:
            xid = None
        match = re.search(log_qname, log)
        if match:
            qname = match.group(1)
        else:
            qname = None
        match = re.search(log_qtype, log)
        if match:
            qtype = match.group(1)
        else:
            qtype = None
        match = re.search(log_qtypeval, log)
        if match:
            qtypeval = match.group(1)
        else:
            qtypeval = None
        match = re.search(log_qclass, log)
        if match:
            qclass = match.group(1)
        else:
            qclass = None
        match = re.search(log_error, log)
        if match:
            error = match.group(1)
        else:
            error = None
        match = re.search(log_rcode, log)
        if match:
            rcode = match.group(1)
        else:
            rcode = None
        match = re.search(log_ref, log)
        if match:
            ref = match.group(1)
        else:
            ref = None
        match = re.search(log_incidentserialno, log)
        if match:
            incidentserialno = match.group(1)
        else:
            incidentserialno = None
        match = re.search(log_msg, log)
        if match:
            msg = match.group(1)
        else:
            msg = None
        match = re.search(log_crscore, log)
        if match:
            crscore = match.group(1)
        else:
            crscore = None
        match = re.search(log_craction, log)
        if match:
            craction = match.group(1)
        else:
            craction = None
        match = re.search(log_crlevel, log)
        if match:
            crlevel = match.group(1)
        else:
            crlevel = None
        match = re.search(log_logdesc, log)
        if match:
            logdesc = match.group(1)
        else:
            logdesc = None
        writer.writerow([month,date_1, time_1,device, date_2, time_2, devname,devid,eventtime,tz,logid,maintype,subtype,eventtype,level
                        ,vd,severity,srcip,srcport,srcintf,srcintfrole,dstip,dstport,dstintf,dstintfrole,srccountry
                        ,dstcountry,sessionid,proto,action,policyid,policytype,poluuid,service,trandisp,appcat
                        ,applist,duration,sentbyte,rcvdbyte,sentpkt,rcvdpkt,direction,attack,attackid,profile,xid,qname,qtype,qtypeval,qclass,error,rcode,ref,incidentserialno,msg,crscore,craction,crlevel,logdesc])
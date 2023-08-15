<h3>Простой WMI агент </h3>
Собирает общую информацию о РС и его
дисках (размер, свободное место).
Основная логика в файле BL.cs
Интерфейс IPcmanager собирает информацию
о PC и дисках, модель данных в классах
PC.cs и Disk.cs. Потом информация сериализуется
в JSON формат.  Интерфейс IClient отпарвляет полученную 
JSON строку запросом http Post на тестовую бесплатную 
WebAPI, получает ответ и выводит его в консоль.

Ниже пример консольного вывода:


C:  254238171136  42679726080
R:  20890720927744  1517135273984
S:  85238738944  14890532864
Computer Name : WPET-W10-P10112
Windows Directory : C:\WINDOWS
Operating System: Microsoft Windows 10 Enterprise
Version: 10.0.19044
Manufacturer : Microsoft Corporation

 ===== JSON data ===== :
{"PcInfo":"Computer Name : WPET-W10-P10112\nWindows Directory : C:\\WINDOWS\nOperating System: Microsoft Windows 10 Enterprise\nVersion: 10.0.19044\nManufacturer : Microsoft Corporation\n","Disks":[{"DiskName":"C:","VolumeSize":254238171136,"FreeSpace":42679726080},{"DiskName":"R:","VolumeSize":20890720927744,"FreeSpace":1517135273984},{"DiskName":"S:","VolumeSize":85238738944,"FreeSpace":14890532864}],"PcItems":["Computer Name : WPET-W10-P10112\n","Windows Directory : C:\\WINDOWS\n","Operating System: Microsoft Windows 10 Enterprise\n","Version: 10.0.19044\n","Manufacturer : Microsoft Corporation\n"]}

 ===== Post JSON data, waiting for response ....

{
  "args": {},
  "data": "{\"PcInfo\":\"Computer Name : WPET-W10-P10112\\nWindows Directory : C:\\\\WINDOWS\\nOperating System: Microsoft Windows 10 Enterprise\\nVersion: 10.0.19044\\nManufacturer : Microsoft Corporation\\n\",\"Disks\":[{\"DiskName\":\"C:\",\"VolumeSize\":254238171136,\"FreeSpace\":42679726080},{\"DiskName\":\"R:\",\"VolumeSize\":20890720927744,\"FreeSpace\":1517135273984},{\"DiskName\":\"S:\",\"VolumeSize\":85238738944,\"FreeSpace\":14890532864}],\"PcItems\":[\"Computer Name : WPET-W10-P10112\\n\",\"Windows Directory : C:\\\\WINDOWS\\n\",\"Operating System: Microsoft Windows 10 Enterprise\\n\",\"Version: 10.0.19044\\n\",\"Manufacturer : Microsoft Corporation\\n\"]}",
  "files": {},
  "form": {},
  "headers": {
    "Content-Length": "609",
    "Content-Type": "application/json; charset=utf-8",
    "Host": "httpbin.org",
    "X-Amzn-Trace-Id": "Root=1-646f5757-3008a8b92111cdbc657a17a0"
  },
  "json": {
    "Disks": [
      {
        "DiskName": "C:",
        "FreeSpace": 42679726080,
        "VolumeSize": 254238171136
      },
      {
        "DiskName": "R:",
        "FreeSpace": 1517135273984,
        "VolumeSize": 20890720927744
      },
      {
        "DiskName": "S:",
        "FreeSpace": 14890532864,
        "VolumeSize": 85238738944
      }
    ],
    "PcInfo": "Computer Name : WPET-W10-P10112\nWindows Directory : C:\\WINDOWS\nOperating System: Microsoft Windows 10 Enterprise\nVersion: 10.0.19044\nManufacturer : Microsoft Corporation\n",
    "PcItems": [
      "Computer Name : WPET-W10-P10112\n",
      "Windows Directory : C:\\WINDOWS\n",
      "Operating System: Microsoft Windows 10 Enterprise\n",
      "Version: 10.0.19044\n",
      "Manufacturer : Microsoft Corporation\n"
    ]
  },
  "origin": "212.176.193.169",
  "url": "https://httpbin.org/post"
}


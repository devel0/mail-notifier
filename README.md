# mail-notifier

simple mail notifier webapi

## usage

```
curl "http://localhost:5000/mail?subj=test&body=$(echo "message with <b>bold</b>" | uriencode)"
curl "http://localhost:5000/mail?from=from@some.com&to=to@some.com&subj=test&body=testbody"
```

- [uriencode tool](https://github.com/devel0/linux-scripts-utils/blob/308a7d462a0743a80a6e3f2571bcfc8ef34815ab/uriencode)

### config

create a file `~/.config/mail-notifier/config.json` ( 700 mode )

```
{
    "login": "user@some.com",
    "password": "pass",
    "smtpserver": "smtp.some.com",
    "smtpport": 465,
    "sslmode": true
}
```

notes
- it doesn't work for gmail account because OAuth2 required or allow less secure app enabled

## how this project was created

```sh
mkdir mail-notifier
cd mail-notifier

dotnet new webapi -n mail-notifier
cd mail-notifier
dotnet add package Newtonsoft.Json --version 12.0.1
dotnet add package Mono.Posix.NETStandard --version 1.0.0
dotnet add package MailKit --version 2.1.1
```

## security considerations

- enforce [firewall rules](https://github.com/devel0/linux-scripts-utils/blob/master/fw.sh) to allow access to this webapi only from trusted ip addresses
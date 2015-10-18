# clipboard-logger
A small but very handy utility that logs whatever text you copy/cut to a log file

-What's this?

ClipboardLogger is a C# winform application that will prevent any 'text' data from getting lost from you
when you copy/cut a text and then forget to paste it or copy/cut something above it so it'll get lost.

-How does it work? 

When you run the program, it will monitor the clipboard so that every time you copy/cut a text, it will automaticallly append it to a text file in your MyDocuments folder. The file is called ClipboardLog.txt. You'll see all the stuff you copied/cut organized in a way that will even show you the data-time of the operation.

NOTE: When you run the program, it will copy it self to your startup folder so that it'll start itself automatically when you
boot up and log in to windows.

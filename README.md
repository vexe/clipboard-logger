# clipboard-logger

Another one of my old programs.

A small but very handy C# utility that logs whatever text you copy/cut to a log file to prevent any textual data from getting lost on accident when you copy/cut a text and then forget to paste it or copy/cut something above it so it'll get lost.

When you run the program, it will monitor the clipboard so that every time you copy/cut a text, it will automaticallly append it to a text file in your MyDocuments folder. The file is called ClipboardLog.txt. You'll see all the stuff you copied/cut organized in a way that will even show you the data-time of the operation.

NOTE: The program will copy itself to your startup folder so that it'll start itself automatically when you
boot up and log in to Windows.

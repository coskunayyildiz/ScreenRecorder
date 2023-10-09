@echo off
setlocal enabledelayedexpansion

set "inputFolder=."
set "ffmpegPath=ffmpeg.exe"

for %%f in ("%inputFolder%\*.avi") do (
    set "inputFile=%%~nf%%~xf"
    
    echo Processing !inputFile!...
    
    "%ffmpegPath%" -i "%%f" -vf "scale=1280:720" -b:v 1500k -c:v libx264 -c:a aac -strict experimental -b:a 128k -y "!inputFile!"
    
    echo !inputFile! processed and saved in the same folder.
)

endlocal
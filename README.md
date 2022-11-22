# Motivation
Why I created this?
I had 1000 vidoes left to be uploaded to Youtube, and I definately would not like to upload duplicated video.
Then I created this automation program to help me track and move those videos which has been already uploaded to a seperate folder.

# Getting Started
```powershell
./ShareX-LogAuto.exe --log-path="E:\Libraries\Documents\ShareX\Logs\ShareX-Log-2022-11.txt" --only-src="J:\Libraries\Videos\NVCaptured\Counter-strike  Global Offensive" --move-dest="J:\Libraries\Videos\NVCaptured\Counter-strike  Global Offensive\toBeRemoved"
```
If you just want to test it out without actually make any changes on your disk, you may use `--dry-run` argument.

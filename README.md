# Motivation 
Why I created this?
I had 1000 vidoes left to be uploaded to Youtube, and I definately would not like to upload duplicated video.
Then I created this automation program to help me track and move those videos which has been already uploaded to a seperate folder.
為何要做這個？我當時有千部影片等著上傳到 Youtube，且我絕對不想讓重複影片上傳的情況發生。
於是乎，產出了這項小東西，幫我追蹤並且移動那些已經上傳好的影片到另外的資料夾。

# Getting Started
```powershell
./ShareX-LogAuto.exe --log-path="E:\Libraries\Documents\ShareX\Logs\ShareX-Log-2022-11.txt" --only-src="J:\Libraries\Videos\NVCaptured\Counter-strike  Global Offensive" --move-dest="J:\Libraries\Videos\NVCaptured\Counter-strike  Global Offensive\toBeRemoved"
```
If you just want to test it out without actually make any changes on your disk, you may use `--dry-run` argument.
如果你只想知道執行結果，但不想真的在你的硬碟上做任何改變，你可以使用 `--dry-run` 參數。

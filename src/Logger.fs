module Logger

open Config
open System
open System.IO

let private getCurrentDate () = (DateTime.Today.ToString("yyyy.MM.dd"))

let private getCurrentTime () =
    (DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss"))

let logRecord logMessage =
    let logFile = logFolder + sprintf "%s.log" (getCurrentDate ())
    use writer = File.AppendText(logFile)
    writer.WriteLine(sprintf "%s - %s" (getCurrentTime ()) logMessage)

module Logging

open Config
open System
open System.IO

let logRecord logMessage =
    let currentDate = (DateTime.Today.ToString("yyyy.MM.dd"))
    let currentTime = (DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss"))
    let logFile = logFolder + sprintf "%s.log" currentDate
    use writer = File.AppendText(logFile)
    writer.WriteLine(sprintf "%s - %s" currentTime logMessage)

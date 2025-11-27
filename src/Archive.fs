module Archive

open Config
open Logger
open System.IO

let archiveFiles groupedFiles =
    if not (Directory.Exists(archiveFolder)) then
        Directory.CreateDirectory(archiveFolder) |> ignore

    logRecord "Starting file archive..."

    groupedFiles
    |> Seq.iter (fun (groupKey, dataSeq) ->
        let destinationPath = archiveFolder

        dataSeq
        |> Seq.iter (fun (_, (sourcePath: string)) ->
            let fileName = Path.GetFileName(sourcePath)
            let filePath = Path.Combine(destinationPath, fileName)

            try
                File.Move(sourcePath, filePath, overwrite = true)
                let archiveSuccessMsg = sprintf "Moved file: %s to %s" fileName filePath
                logRecord archiveSuccessMsg
            with ex ->
                let archiveFailureMsg = sprintf "Error archiving file %s: %s" fileName ex.Message
                logRecord archiveFailureMsg))

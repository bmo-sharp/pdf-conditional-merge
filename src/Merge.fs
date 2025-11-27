module Merge

open Config
open Logger
open System.IO
open Docnet.Core

let mergeGroups groupedFiles =
    if not (Directory.Exists(outputFolder)) then
        Directory.CreateDirectory(outputFolder) |> ignore

    let mergeBeginMsg = sprintf "Starting PDF merge and output to %s..." outputFolder
    logRecord mergeBeginMsg

    groupedFiles
    |> Seq.filter (fun (groupKey, _) -> groupKey <> "Ungrouped")
    |> Seq.iter (fun (groupKey, dataSeq) ->
        let sourceFileBytesList =
            dataSeq
            |> Seq.map (fun (_, filePath) -> filePath)
            |> Seq.map File.ReadAllBytes
            |> List.ofSeq

        let mergedFileBytes = DocLib.Instance.Merge(sourceFileBytesList)

        let fileName = sprintf "%s_FINAL.pdf" groupKey
        let outputPath = Path.Combine(outputFolder, fileName)

        try
            File.WriteAllBytes(outputPath, mergedFileBytes)
        with ex ->
            let mergeErrorMsg = sprintf "Error writing merged file %s: %s" fileName ex.Message
            logRecord mergeErrorMsg)

    logRecord "PDF merging complete."

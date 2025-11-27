module Extraction

open Config
open Logger
open System.IO
open Docnet.Core
open Docnet.Core.Models

let private defaultDimensions = PageDimensions(1000, 1000)

let private pdfExtract (filePath: string) =
    let fileBytes = File.ReadAllBytes(filePath)

    use reader = DocLib.Instance.GetDocReader(fileBytes, defaultDimensions)
    use pageReader = reader.GetPageReader(0)
    let pageText = pageReader.GetText()

    let matchResult = regexPattern.Match(pageText)

    let groupValue =
        if matchResult.Success then
            matchResult.Value
        else
            "Ungrouped"

    (groupValue, filePath)

let getGroupedFiles () =
    let files = Directory.EnumerateFiles(inputFolder, "*.pdf")

    if Seq.isEmpty files then
        logRecord "No PDF files found."
        Seq.empty
    else
        logRecord "Starting PDF grouping."

        let extractedValues = files |> Seq.map pdfExtract

        let groupedFiles = extractedValues |> Seq.groupBy (fun (group, _) -> group)

        groupedFiles

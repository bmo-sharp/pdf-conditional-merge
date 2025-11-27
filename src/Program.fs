open Extraction
open Logger
open Archive
open Merge

[<EntryPoint>]

let main argv =

    logRecord "Process beginning..."

    let groupedData = getGroupedFiles ()

    if not (Seq.isEmpty groupedData) then

        mergeGroups groupedData

        archiveFiles groupedData

        logRecord "Process Complete.\n"

    else
        logRecord "Process finished with no files found.\n"

    0

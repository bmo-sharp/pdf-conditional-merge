module Config

open System.Text.RegularExpressions

let inputFolder = @"input folder path as string"

let outputFolder = @"output folder path as string"

let archiveFolder = @"archive folder path as string"

let logFolder = @"log folder path as string"

let regexPattern = new Regex(@"regex pattern as string")

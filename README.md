# pdf-conditional-merge
Merge PDFs based on internal ID keys, implemented in F# with Docnet.Core

This project is to merge PDF files based on an ID key contained within the text
of the PDF itself, as opposed to the file name. The Extract module reads the
text from the first page of each PDF before performing regex to find the ID key,
then groups files together based on shared ID keys. The Merge module contains
the merging logic, ignoring any files for which no regex match was found. The
resulting merged PDFs are saved to an output folder. The Archive module handles
archiving both the matched and unmatched files from the input folder. There is
some minimal logging to track each run and record any error messages.

This project was inspired by a real business use case in which logistics system
would generate multiple shipping documents for each order shipped. The business
requested a single combined document for each order, but was told the system
would not be able to accomodate that request. Additionally, some of the
documents generated did not display the order number in the file name itself.
The solution was a utility similar to this one which would run periodically to
combine all PDF files for the same order into a single document.

All licenses for third-party dependencies can be found in the licenses folder.
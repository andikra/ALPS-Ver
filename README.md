# ALPS Verification
This console application is part of my master thesis at the Karlsruher Institute of Technology (KIT) and uses the apls.net.api to verify ALPS Models. To use this application, you need an abstract model (Specification) and an implementing model (Implementation). The program then checks based on the alps.net.api, if the implementation adheres to the restrictions and rules implied by the specification. 



# alps.net.api

This C# library provides the functionality to create and modify in-memory PASS process models.
These models might either be imported from an ontology (given in the owl/rdf format) or created from scratch.

The library currently supports the [Standard PASS](https://github.com/I2PM/Standard-PASS-Ontology) as well as the Abstract Layered PASS created by Matthes Elstermann.
For more information have a look at the [wiki pages](https://github.com/I2PM/alps.net.api/wiki) or at the HTML/XML doc inside the classes (this is why the project mostly consists of html code).

A library with the name of this repository is also published in the NuGet store and available for download.
Currently the library is targeting .NET Core 3.1 (netcoreapp3.1) as well as .NET Framework 4.72 (net472)

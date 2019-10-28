![Carto-chan](https://raw.githubusercontent.com/TraduSquare/Carto-chan/master/logo.png)
# Carto-chan
A simple converter for Cartographer (And Atlas) TXT format to Po.

# Usage
Carto-chan <-txt/-po/credits> "file" "language" 
(If you don't specify any language, the default will be "es")

* Convert TXT to Po: Carto-chan -txt lb_script_001.txt en
* Convert Po to TXT: Carto-chan -po lb_script_001.po
* Show the credits: Carto-chan credits

# Changelog
## 1.0
* Initial version

## 1.1
* Updated Net Framework to 4.7.2
* Added a language selector when export txt to po

## 1.2
* Updated to NET Core 3
* Rewrited compatibility with the txt files and now support Atlas scripts

# Dictionary
If you need to replace some strings (like [LINE] to \n), create a "Dictionary.txt" file on the program folder and put "Value original"="Value replaced" like this ([LINE]=\n) and Carto-chan will replace the strings.
![Dictionary](https://raw.githubusercontent.com/TraduSquare/Carto-chan/master/ExampleDictionary.png)

# Credits
* Thanks to Pleonex for Yarhl libraries.
* Carto-chan's logo has been originally created in its entirety by JohnSu and thus all rights belong to him
* https://www.deviantart.com/johnsu/art/Global-Cartographer-Atlyss-560955860

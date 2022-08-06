# BrowserRouter

Window Browser Multiplexer. I wrote this in 2009. It registers itself as the default browser on Windows, and then delegates 
opening links to a series of browsers (e.g. IE6, IE8, Chrome, Firefox) based on rules.

The purpose of this was to allow old-school links to internal systems to open in IE6 (the only thing they supported), while
everything else could open in the browser of your choice. Remember, this was the dark ages.

A modern equivalent would be [Sindresorhus' Velja](https://sindresorhus.com/velja) for MacOS.

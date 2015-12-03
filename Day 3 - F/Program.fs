open System
open System.IO

let path = "C:\\TextFile1.txt"
let file = new StreamReader(path)
let zone = Array2D.create 999 999 0
let mutable x = 500
let mutable y = 500

let mutable xrobo = 500
let mutable yrobo = 500

let mutable tour = true

let mutable total = 0 

while not file.EndOfStream  do
    let char =  file.Read()
    if tour then
        if char = 60 then x <- x - 1
        if char = 62 then x <- x + 1
        if char = 94 then y <- y - 1
        if char = 118 then y <- y + 1
        zone.[x , y] <- 1
        tour <- false
    else
        if char = 60 then xrobo <- xrobo - 1
        if char = 62 then xrobo <- xrobo + 1
        if char = 94 then yrobo <- yrobo - 1
        if char = 118 then yrobo <- yrobo + 1
        zone.[xrobo , yrobo] <- 1
        tour <- true

    

for i in zone do
    if i.ToString() = "1" then total <- total + 1
    

Console.WriteLine(total.ToString());
let t = Console.ReadLine();

     
  
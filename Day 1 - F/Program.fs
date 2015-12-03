open System
open System.IO

let path = "C:\\TextFile1.txt"
let mutable number = 0   
let mutable basement = 0

let file = new StreamReader(path) 
while not file.EndOfStream do
    let char = file.Read()
    if char = 40 then number <- number + 1
    if char = 41 then number <- number - 1
    basement <- basement + 1 
    if number = -1 then Console.WriteLine("Basement : " + basement.ToString())

Console.WriteLine(number)
let l = Console.ReadLine()

open System

type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure

type Person = {Name:string; Email:string}

let validateEmail person =
    if person.Email |> String.IsNullOrEmpty then Failure "Email cannot be empty"
    else Success person  // happy path

let validateName person =
    if person.Name |> String.IsNullOrEmpty then Failure "Name cannot be empty"
    else Success person

let jeremy = {Name = "Jeremy"; Email = ""}

// wouldn't it be nice if
// let validatePerson = validateEmail >> validateName
// We can't because the output of validateEmail doesn't match the type of validvalidateName

let bind switchFunction = 
    fun twoTrackInput -> 
        match twoTrackInput with
        | Success s -> switchFunction s // the output of the success function does not have to be the same as the input's success type
        | Failure f -> Failure f

let validateName' = bind validateName

let validatePerson = validateEmail >> validateName'
let result = validatePerson jeremy
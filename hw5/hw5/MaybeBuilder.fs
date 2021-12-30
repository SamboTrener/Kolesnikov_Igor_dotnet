module hw5.MaybeBuilder

type MaybeBuilder() =
    member b.Bind(x, foo) =
        match x with
        | Ok y -> foo y
        | Error error -> Error error
    member b.Return x = Ok x
let maybeBuilder = MaybeBuilder()
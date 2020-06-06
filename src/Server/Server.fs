module safetest.Server

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Saturn
open safetest.Shared

let counterApi =
    { getInitialCounter = async { return { Value = 42 } } }

let webApp =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue counterApi
    |> Remoting.buildHttpHandler

let app =
    application {
        url "http://0.0.0.0:8085"
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

run app
#r "../_lib/Fornax.Core.dll"
#load "partials/layout.fsx"

open Html


let generate' (ctx : SiteContents) (page: string) =
    let posts =
        ctx.TryGetValues<Contentloader.Post> ()
        |> Option.defaultValue Seq.empty

    // printfn "POSTS: %A" posts
    let post = posts |> Seq.find (fun n -> n.file = page)

    Layout.layout ctx [ !! post.content ] page

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
    try
        generate' ctx page
        |> Layout.render ctx
    with
    | ex ->

        printfn "PAGE: %s" page
        printfn "EX: %A" ex
        ""
Simplo7 API .NET Client
=========

- C#
```csharp
var api = new Simplo7.API("50514","NGUwNTQ5Z1U3ZGZh3jM2MDVkMGJkZ23NmU4ZjNkZDg");
var produtos = api.call(Endpoints.Produtos);
foreach(var produto in produtos) {
  var id = produto["Wsproduto"]["id"];
}

var novaCategoria = api.call(Endpoints.Categorias, Methods.Post, new { nome = "nova categoria" });
var idDaNovaCategoria = novaCategoria["Wscategoria"]["id"];

```

- Visual Basic
```vb
Dim api = New Simplo7.API("50514", "NGUwNTQ5Z1U3ZGZh3jM2MDVkMGJkZ23NmU4ZjNkZDg")
Dim produtos = api.call(Endpoints.Produtos)

For Each produto In produtos
  Dim id = produto("Wsproduto")("id")
Next

Dim novaCategoria = api.call(Endpoints.Categorias, Methods.Post, New With { Key .nome = "nova categoria" })
Dim idDaNovaCategoria = novaCategoria("Wscategoria")("id")
```
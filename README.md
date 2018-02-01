# Client .NET para acesso às APIs do Simples Nacional

Este repositório contém o código fonte e exemplos de uso do client .NET para acesso ao Simples Nacional ACL.

## Instalação
```sh
$ dotnet add package ACL.SimplesNacional.Client --version 0.3.0
```

---

# Consultas disponíveis

## Análises com potencial de cobrança
- [X] Listagem de contribuintes que ultrapassaram sublimite estadual/nacional
- [X] Listagem de diferenças de alíquotas em NFS-es com imposto retido


## Informações do contribuinte
- [ ] Extrato da DAS-D
- [X] Listagem de eventos do Simples Nacional (inclusão/exclusão)

---

# Exemplo

```csharp
using (var client = new SimplesNacionalClient("Id", "Senha"))
{
    var eventos = await client.ListarEventos("CNPJ base");
    var sublimites = await client.ListarSublimites("Código TOM", 2018, 1);
}
```

Exemplos completos disponíveis [neste link](https://github.com/arortega/simples-nacional-client-net/tree/master/exemplos)

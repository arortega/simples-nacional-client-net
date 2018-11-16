# Client .NET para acesso às APIs do Simples Nacional

Este repositório contém o código fonte e exemplos de uso do client .NET para acesso ao Simples Nacional ACL.

## Instalação
```sh
$ dotnet add package ACL.SimplesNacional.Client --version 0.7.1
```

---

# Consultas disponíveis

## Análises com potencial de cobrança
- [X] Listagem de contribuintes que ultrapassaram sublimite estadual/nacional
- [X] Listagem de divergências com seus respectivos valores


## Informações do contribuinte
- [ ] Extrato da DAS-D
- [X] Listagem de eventos do Simples Nacional (inclusão/exclusão)
- [X] Situação SN/MEI

---

# Exemplo

```csharp
using (var client = new SimplesNacionalClient("Id", "Senha"))
{
    var baseCalculoProprio = await client.ListarDivergencias<ValoresDiferencaBaseCalculoProprio>(
        codigoTOM: "8531",
        ano: 2017,
        mes: 2,
        dataCriacao: new DateTime(2018, 10, 10, 13, 40, 0, DateTimeKind.Utc)
        );

    var eventos = await client.ListarEventos("CNPJ base");
    var sublimites = await client.ListarSublimites("Código TOM", 2018);
    var situacao = await client.ObterSituacaoContribuinte("CNPJ base");
}
```

Exemplos completos disponíveis [neste link](https://github.com/arortega/simples-nacional-client-net/tree/master/exemplos)

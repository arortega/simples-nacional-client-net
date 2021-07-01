# Client .NET para acesso às APIs do Simples Nacional

Este repositório contém o código fonte e exemplos de uso do client .NET para acesso ao Simples Nacional ACL.

## Instalação
```sh
$ dotnet add package ACL.SimplesNacional.Client --version 0.8.0
```

---

# Consultas disponíveis

## Análises com potencial de cobrança
- [X] Listagem de contribuintes que ultrapassaram sublimite estadual/nacional
- [X] Listagem de divergências com seus respectivos valores
- [X] Listagem de mensagens não lidas do DEC


## Informações do contribuinte
- [ ] Extrato da DAS-D
- [X] Listagem de eventos do Simples Nacional (inclusão/exclusão)
- [X] Situação SN/MEI

---

# Exemplo

```csharp
using (var client = new SimplesNacionalClient("Id", "Senha"))
{
    var enquadramentos = await client.ObterEnquadramentos("CNPJ");
    var situacao = await client.ObterSituacoesFiscais(List<"CNPJ">);
    var mensagens = await client.ObterMensagensNaoLidas("CNPJ");
}
```

Exemplos completos disponíveis [neste link](https://github.com/arortega/simples-nacional-client-net/tree/master/exemplos)

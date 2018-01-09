# Client .NET para acesso às APIs do Simples Nacional

Este repositório contém o código fonte e exemplos de uso do client .NET para acesso ao Simples Nacional ACL.

## Instalação
```sh
$ dotnet add package ACL.SimplesNacional.Client --version 0.1.0
```

---

# Consultas disponíveis

## Análises com potencial de cobrança
- [ ] Listagem de contribuintes que ultrapassaram sublimite estadual/nacional
- [X] Listagem de diferenças de alíquotas em NFS-es com imposto retido


## Informações do contribuinte
- [ ] Extrato da DAS-D
- [ ] Listagem de eventos do Simples Nacional (inclusão/exclusão)

---

# Exemplo

```csharp
var client = new SimplesNacionalClient("https://simplesnacional.aclti.com.br");
var lista = await client.ListarDiferencasAliquota("9999"); //Codigo TOM do município
```

Exemplos completos disponíveis [neste link](https://github.com/arortega/simples-nacional-client-net/tree/master/exemplos)

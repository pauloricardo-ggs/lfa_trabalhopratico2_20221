# Trabalho realizado para a segunda unidade da disciplina Linguagens Formais e Autômatos 2022.1
Professor Adolfo Guimarães
#
Realizado por Paulo Ricardo e Alexandre Rosendo
#
Instruções:
- A gramática deve ser colocada no arquivo `Gramatica.txt`
- A regra inicial deve possuir nome `S`
- Cada regra deve estar em uma linha diferente
- As regras devem seguir o formato `NomeDaRegra => Producao` ou `NomeDaRegra => Producao1 | Producao2`
- Os caracteres `=`, ` `, `>` e `|` não podem ser utilizados nos nomes das regras nem produções pois são reservados para o sistema
#
Exemplos de gramáticas aceitas:<br /><br />

1.  `S => XB | AB`<br />
    `X => AS`<br />
    `A => a`<br />
    `B => b`<br /><br />
    
2.  `S => XB` <br />
    `S => AB | AS` <br />
    `X => AS`<br />
    `A => a | b`<br />
    `B => c`
#
Exemplos de gramáticas não aceitas:<br /><br />

1.  (Não possui regra inicial S)<br />
    `X => AB`<br />
    `A => a`<br />
    `B => b`<br /><br />
    
2.  (Uso de caracteres reservados)<br />
    `S => XB | AB`<br />
    `X => >`<br />
    `A => =`<br />
    `B => b`<br /><br />
    
3.  (Mais de uma regra na mesma linha)<br />
    `S => XB | AB X => AS A => a B => b`
#
Obs: Algumas gramáticas que não seguirem as instruções poderão não exibir erro, mas não resultarão em uma resposta correta.

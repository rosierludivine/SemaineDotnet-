using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

class Exercice (){

    // Probleme retenu de cette exeercice ces une boucle sans fin et il ne retourner rien resolution de la boucle pas le temps de la faire 
    public static int Sum(IEnumerable<object> values){
        var sum = 0; 
        foreach (var item in values){
            switch(item){
                case 0:
                break; 
                case int val: 
                sum += val; 
                break; 
                case IEnumerable<object> subList when subList.Any():
                sum += Sum (subList);
                break; 

            }
        }
        return sum; 
    }
}
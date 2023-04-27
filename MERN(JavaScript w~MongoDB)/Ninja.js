// const ninja1 = new Ninja("Hyabusa");
// ninja1.sayName();
// ninja1.showStats();


class Ninja{
    constructor(){
    this.speed = 3;
    this.sayName = "greg";
    this.strength = 3;
    this.health = 100
    }
    
    sayName(){
        this.sayName
    }
    showStats(){
        this.sayName
        this.strength
        this.speed
        this.health
    }
    drinkSake(){
        this.health =+ 10
    }

}

class Sensei extends Ninja{
    constructor(){
        super()
        this.health =+ 100;
        this.speed =+ 7;
        this.strength =+ 7;
        this.wisdom = 10;
    }
    speakwisdom(){
        this.wisdom
    }
}

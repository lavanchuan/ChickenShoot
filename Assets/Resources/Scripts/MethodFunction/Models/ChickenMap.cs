using UnityEngine;
public class ChickenMap{
    public int sumChickenInvader {get;set;}
    public int[,] map {get;set;}
    public ChickenMap Map01(){
        this.map = new int[,]{
            {1,1,1,1,1,1,1,1,1},
            {0,1,1,1,1,1,1,1,0},
            {0,0,1,1,1,1,1,0,0},
            {0,0,0,1,1,1,0,0,0},
            {0,0,0,0,1,0,0,0,0}
        };
        this.sumChickenInvader = 0;
        for(int i = 0; i < map.GetLength(0); i++){
            for(int j = 0; j < map.GetLength(1); j++){
                this.sumChickenInvader += (int)map.GetValue(i,j);
            }
        }
        return this;
    }

    public ChickenMap Map02(){
        this.map = new int[,]{
            {1,0,1,0,1,0,1,0,1},
            {0,1,0,1,0,1,0,1,0},
            {1,0,1,0,1,0,1,0,1},
            {0,1,0,1,0,1,0,1,0},
            {1,0,1,0,1,0,1,0,1}
        };
        this.sumChickenInvader = 0;
        for(int i = 0; i < map.GetLength(0); i++){
            for(int j = 0; j < map.GetLength(1); j++){
                this.sumChickenInvader += (int)map.GetValue(i,j);
            }
        }
        return this;
    }

    public ChickenMap Map03(){
        this.map = new int[,]{
            {1,1,1,0,1,1,1,0,1,1,1,0,1,1,1},
            {0,1,1,1,0,1,1,1,0,1,1,1,0,1,1},
            {1,0,1,1,1,0,1,1,1,0,1,1,1,0,1},
            {1,1,0,1,1,1,0,1,1,1,0,1,1,1,0},
            {1,1,1,0,1,1,1,0,1,1,1,0,1,1,1}
        };
        this.sumChickenInvader = 0;
        for(int i = 0; i < map.GetLength(0); i++){
            for(int j = 0; j < map.GetLength(1); j++){
                this.sumChickenInvader += (int)map.GetValue(i,j);
            }
        }
        return this;
    }

    public ChickenMap Map04(){
        this.map = new int[,]{
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
        this.sumChickenInvader = 0;
        for(int i = 0; i < map.GetLength(0); i++){
            for(int j = 0; j < map.GetLength(1); j++){
                this.sumChickenInvader += (int)map.GetValue(i,j);
            }
        }
        return this;
    }

    public ChickenMap Map05(){
        this.map = new int[,]{
            {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1},
            {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
            {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
            {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
            {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1},
        };
        this.sumChickenInvader = 0;
        for(int i = 0; i < map.GetLength(0); i++){
            for(int j = 0; j < map.GetLength(1); j++){
                this.sumChickenInvader += (int)map.GetValue(i,j);
            }
        }
        return this;
    }

    public ChickenMap Map06(){
        this.map = new int[,]{
            {1,1,1,1,1,0,0,0,1,1,0,0,1,1,1,1,1},
            {1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,0},
            {1,1,0,0,1,1,0,0,1,1,0,0,1,1,1,1,1},
            {1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,0},
            {1,1,1,1,1,0,0,0,1,1,0,0,1,1,1,1,1},
        };
        this.sumChickenInvader = 0;
        for(int i = 0; i < map.GetLength(0); i++){
            for(int j = 0; j < map.GetLength(1); j++){
                this.sumChickenInvader += (int)map.GetValue(i,j);
            }
        }
        return this;
    }

    public ChickenMap MapRandom(){
        int mapCount = 6;
        ChickenMap cm = new ChickenMap();
        int mapIndex = 1 + UnityEngine.Random.Range(1000, 10000) % mapCount;
        // DEBUG
        // mapIndex = 6;
        // Debug.Log(mapIndex);
        switch(mapIndex){
            case 1:
            cm = Map01();
            break;
            case 2:
            cm = Map02();
            break;
            case 3:
            cm = Map03();
            break;
            case 4:
            cm = Map04();
            break;
            case 5:
            cm = Map05();
            break;
            case 6:
            cm = Map06();
            break;
        }
        return cm;
    } 
}
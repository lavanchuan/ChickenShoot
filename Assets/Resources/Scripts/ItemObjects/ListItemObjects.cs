using System.Collections;

public class ListItemObjects{
    public ArrayList listItemObject;
    public ListItemObjects(){
        Setup();
    }

    void Setup(){
        listItemObject = new ArrayList();

        // Coin
        listItemObject.Add(new RateItemObject(Coin.NAME, Coin.DROP_RATE));
        // Upgrade bullet quantity
        listItemObject.Add(new RateItemObject(UpgradeBulletQuantity.NAME, UpgradeBulletQuantity.DROP_RATE));
        // Foods
        listItemObject.Add(new RateItemObject(Food.NAME+"01", 90f));
        listItemObject.Add(new RateItemObject(Food.NAME+"02", 80f));
        listItemObject.Add(new RateItemObject(Food.NAME+"03", 70f));
        listItemObject.Add(new RateItemObject(Food.NAME+"04", 60f));
        listItemObject.Add(new RateItemObject(Food.NAME+"05", 50f));
        listItemObject.Add(new RateItemObject(Food.NAME+"06", 40f));
        
    }
}
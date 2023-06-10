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

    }
}
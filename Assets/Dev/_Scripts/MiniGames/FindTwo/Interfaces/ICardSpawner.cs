using System.Collections.Generic;

public interface ICardSpawner
{
    void SpawnCards();
    List<ICard> GetCards();
}
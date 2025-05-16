# PlayerManagerMVC

## Diagrama de Classes

```mermaid
classDiagram
    class Controller {
        -ModelData model
        +AddPlayer(name: string, score: int)
        +GetAllPlayers() IEnumerable<Player>
        +GetPlayersWithScoreGreaterThan(minScore: int) IEnumerable<Player>
        +SortPlayers(order: PlayerOrder)
    }
    class ModelData {
        -List<Player> players
        -IComparer<Player> compareByName
        -IComparer<Player> compareByNameReverse
        +AddPlayer(player: Player)
        +GetAllPlayers() IEnumerable<Player>
        +GetPlayersWithScoreGreaterThan(minScore: int) IEnumerable<Player>
        +SortPlayers(order: PlayerOrder)
    }
    class Player {
        +Name: string
        +Score: int
        +CompareTo(other: Player) int
    }
    class CompareByName {
        -bool ord
        +Compare(p1: Player, p2: Player) int
    }
    enum PlayerOrder {
        ByScore
        ByName
        ByNameReverse
    }
    Controller --> ModelData
    ModelData --> "*" Player
    ModelData --> "2" CompareByName
    ModelData --> PlayerOrder
    CompareByName ..|> IComparer
    Player ..|> IComparable

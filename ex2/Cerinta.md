# Exercitiul 2 — Observer: un eveniment, N reactii

## Context

Aceeasi comanda din magazin, dar acum urmarim **starea** ei: `Plasata` -> `Expediata` -> `Livrata`. La FIECARE schimbare de stare, mai multe parti trebuie sa reactioneze:

- clientul primeste un email;
- se scrie o linie in jurnalul de livrari;
- depozitul isi pregateste pasul urmator.

Prima varianta la care se gandeste oricine — si e din nou o capcana:

```csharp
public void SchimbaStare(string stareNoua)
{
    Stare = stareNoua;
    email.Trimite(stareNoua);
    jurnal.Scrie(stareNoua);
    depozit.Pregateste(stareNoua);
}
```

`Comanda` ajunge sa cunoasca fiecare parte concreta pe nume. Cand marketingul cere si o notificare push, RE-DESCHIZI `SchimbaStare` si mai adaugi o linie — iar `Comanda`, care ar trebui sa se ocupe de comanda, stie acum despre email, SMS, jurnal, depozit, push... Fix problema de la ex1 (Strategy), dar pe alta axa: acolo se schimba **CUM se calculeaza**, aici se schimba **CINE reactioneaza**.

## Ideea

Inversezi dependenta. `Comanda` (numita **Subject**) nu mai cunoaste nicio parte concreta — tine o lista de **observatori** care au semnat un contract, si cand se schimba starea ii **anunta pe toti**, la fel, fara sa stie cine sunt:

```csharp
public interface IObservator
{
    void Actualizeaza(string stareNoua);
}
```

O parte noua care vrea sa reactioneze = o clasa noua care implementeaza `IObservator` si se aboneaza. `Comanda` ramane neatinsa. Asta e **Observer**: o singura sursa de eveniment, N ascultatori care reactioneaza independent.

## Contractul si rolurile

| Rol | In exercitiu | Ce face |
|---|---|---|
| **Subject** (sursa) | `Comanda` | tine observatorii, isi schimba starea, ii anunta pe toti |
| **Observer** (contractul) | `IObservator` | declara `Actualizeaza(string stareNoua)` |
| **ConcreteObserver** | `NotificatorEmail`, `JurnalLivrare`, `PanouDepozit` | fiecare reactioneaza in felul lui |

## Ce afiseaza fiecare observator

| Observator | La `Actualizeaza("X")` afiseaza |
|---|---|
| `NotificatorEmail` | `[EMAIL] Comanda a trecut in starea: X` |
| `JurnalLivrare` | `[LOG] Stare inregistrata: X` |
| `PanouDepozit` | `[DEPOZIT] Pregatesc pentru: X` |

## Pasii (in ordinea asta — primul e capcana)

1. **Simte durerea intai.** Pe ciorna, scrie `SchimbaStare` cu apeluri directe (`email.Trimite(...)`, `jurnal.Scrie(...)`). Raspunde: cate locuri atingi cand adaugi o notificare push? Ce cunoaste `Comanda` si n-ar trebui?
2. **Scoate contractul.** Cele 3 clase implementeaza `IObservator`, fiecare cu afisarea ei.
3. **Fa `Comanda` sa anunte, nu sa stie.** `SchimbaStare(stareNoua)` seteaza `Stare` si apoi PARCURGE observatorii chemand `Actualizeaza(stareNoua)` — cu un `for`, fara sa cunoasca vreo clasa concreta.

## Cerinte

1. Interfata `IObservator` + cele 3 observatoare.
2. `Comanda` (Subject) cu: `Stare` (proprietate citibila), un `IObservator[]` primit prin constructor, si `SchimbaStare(string stareNoua)` care seteaza starea si anunta toti observatorii.
3. `Testare2` (chemata din `Program.cs`): creezi cele 3 observatoare, o `Comanda` cu ele, apoi `SchimbaStare("Expediata")` si `SchimbaStare("Livrata")`. In output trebuie sa vezi, la fiecare schimbare, toate cele 3 reactii — deci 6 linii, grupate cate 3.

## Constrangeri

- `Comanda` NU cunoaste nicio clasa concreta de observator — doar `IObservator`.
- Fara `is`, `as`, `GetType()`. Fara LINQ, `List`, `Dictionary` — doar `IObservator[]` si `for`.
- Mesajele de eroare in engleza.

## Cum rulezi

```bash
dotnet run
```

## Bonus

- Adauga `Aboneaza(IObservator nou)` si `Dezaboneaza(IObservator vechi)` pe `Comanda`, care cresc/micsoreaza array-ul manual (fara `List`). Aboneaza un observator DUPA prima schimbare de stare si observa ca prinde doar schimbarile urmatoare — un observator vede doar ce se intampla dupa ce s-a abonat.
- Intrebare de gandit, legatura cu ex1: la Strategy, `Comanda` avea UN singur colaborator (strategia) si-l INTREBA („cat costa?"). La Observer are MULTI si ii ANUNTA („s-a schimbat starea"). Care e diferenta de directie intre „a intreba" si „a anunta", si de ce Observer nu asteapta niciun raspuns inapoi?

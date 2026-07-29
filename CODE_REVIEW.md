# Code Review — design-patterns-csharp · ex1 Strategy (runda 1)

**Data:** 2026-07-29 · **Commit:** 5f8379d „ex1" · **Build:** trece · **Rulare:** `57.0 / 117.00 / 58.50` — corect

## Ce e corect ✅

- **Strategy aplicat corect.** `Comanda` nu conține niciun `if`/`switch` pe tipul de livrare — ține o `ILivrareStrategie`, deleagă în `CostTransport()` și o schimbă în `SchimbaStrategie()`. Exact miezul pattern-ului.
- **Formulele** din cele 3 strategii sunt corecte (verificat în output: 5+0.5·100+0.1·20=57; 12+1·100+0.25·20=117; 117−50%=58.5).
- **Bonusul (Decorator) e prins.** `LivrareCuReducere` primește altă `ILivrareStrategie` în constructor și îi ajustează rezultatul — ai văzut singur că o strategie poate împacheta altă strategie. Ăsta e exact drumul spre lecția 4.

---

## 🟡 Importante

### M1 — `bin/` și `obj/` au ajuns în git; lipsea `.gitignore`
Repo, nu un fișier anume.

`git add .` a măturat în repo folderele de build (`bin/`, `obj/`) — artefacte generate, care se regenerează la orice `dotnet build`. Nu au ce căuta în istoric: fac diff-uri urâte, umflă repo-ul și pot genera conflicte false. Cauza: proiectul n-avea `.gitignore` (scăparea starterului — l-am adăugat acum, cu `bin/` și `obj/`).

Ce rămâne de făcut (git = manual, îl faci tu):
```bash
git rm -r --cached bin obj
git add .gitignore
git commit -m "gitignore + scoate bin/obj din tracking"
```
După asta, folderele rămân pe disc dar git le ignoră. **Regula:** în git intră doar ce SCRII tu, niciodată ce GENEREAZĂ compilatorul.

### M2 — `Testare1` nu acoperă cerințele 3 și 4
`ex1/Testare1.cs`

Trei lucruri lipsă față de enunț:

1. **`LivrareGratuita` nu e demonstrată.** Cerința 3 cerea explicit Standard → Express → **Gratuita**. Ai înlocuit a treia cu bonusul (`LivrareCuReducere`) — bun că ai testat bonusul, dar strategia gratuită tot trebuie arătată.
2. **Output-ul nu spune CARE strategie a răspuns.** Afișezi doar `comanda.CostTransport()` — trei numere seci. Cerința cerea „numele strategiei ȘI costul". Fără `Nume`, un cititor vede `57 / 117 / 58.5` și nu poate lega numărul de metodă. Tocmai `Nume`-le din contract face vizibil că s-au schimbat strategiile.
3. **Cazul de eroare lipsește.** Cerința 4 cerea o comandă cu greutate `0`, prinsă cu `try/catch (ArgumentException)` și mesajul afișat. Acum validarea din constructor există, dar nu e pusă niciodată la treabă — deci e cod nedovedit (aceeași lecție ca la interfaces: ce nu rulează, nu e dovedit).

### M3 — `LivrareCuReducere` aruncă tipul greșit de excepție
`ex1/Models/LivrareCuReducere.cs:16`

`throw new InvalidCastException("The procent is invalid")` — `InvalidCastException` înseamnă „o conversie de tip a eșuat" (`(int)unObiect`). Aici n-ai nicio conversie; ai un **argument invalid**. Tipul potrivit e `ArgumentException` (sau `ArgumentOutOfRangeException`). Tipul excepției e un mesaj către cine o prinde — pune tipul care descrie adevărata cauză.

| | Acum | Corect |
|---|---|---|
| Excepție | `throw new InvalidCastException("The procent is invalid")` | `throw new ArgumentException("Discount percent must be between 0 and 100")` |

---

## 🟢 Cleanups

- **C1** — `(decimal)0.5 * greutateKg`: cast de la un `double` la `decimal`. Merge, dar idiomatic în C# scrii literalul direct `decimal`: `0.5m`, `0.1m`, `0.25m`, `1.0m`. Bonus: `(decimal)0.1` pleacă de la un `double` care nu reprezintă exact 0.1 — aici se rotunjește ok, dar e un obicei de evitat. Scrie `0.1m` și pornești direct din `decimal`.
- **C2** — `using System.Globalization;` în `LivrareCuReducere.cs:1` nu e folosit. Șterge-l.
- **C3** — `Nume => "Reducere"` e hardcodat, deci decoratorul ascunde CE strategie împachetează. La lecția Decorator vei vrea `strategie.Nume + " (-" + Procent + "%)"` → „Express (-50%)". Deocamdată doar reține întrebarea: un decorator ar trebui să-și piardă complet identitatea celui pe care-l împachetează?
- **C4** — spațiere dublă la `return  costInitial` (`LivrareCuReducere.cs:26`). Cosmetic.

---

## Q&A

**Q1.** Rulezi acum și vezi `57 / 117 / 58.5`. Dacă ți-aș ascunde codul din `Testare1`, ai putea spune din output care număr vine de la care strategie? Ce trebuie să adaugi la afișare ca răspunsul să fie „da"?

**Q2.** `InvalidCastException` vs `ArgumentException`: cine „citește" excepția pe care o arunci și de ce contează pentru el ce tip alegi? Dă un exemplu de cod care ar prinde `ArgumentException` dar NU `InvalidCastException`.

**Q3.** `LivrareCuReducere` primește o `ILivrareStrategie` și e ea însăși o `ILivrareStrategie`. Ce te oprește să bagi o `LivrareCuReducere` în interiorul altei `LivrareCuReducere` (reducere peste reducere)? Ce ar afișa și ar avea sens?

---

*Regula proiectului: codul tău nu se modifică — corectările le aplici tu, pe baza review-ului.*

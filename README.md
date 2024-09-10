[![Typing SVG](https://readme-typing-svg.herokuapp.com?color=%2336BCF7&lines=Описание+библиотеки+классов)](https://git.io/typing-svg)
#### Название библиотеки – LibraryOfLaba4_1.dll
#### Пространство имен - LibraryOfLaba4_1
## Иерархия классов
#### Родительский класс - SumOfMoney
#### Наследуемые классы: 
#### 1) Special
#### 2) Prime
## Классы
### 1.1) Имя – SumOfMoney
#### 1.2) Что за класс – Родительский класс
#### 1.3) Параметры конструктора – конструктор без параметров
#### 1.4) Свойства

|   Название    |   Тип данных  |                   Назначение                                                                                              |
| ------------- | ------------- | ------------------------------------------------------------------------------------------------------------------------  |
|   Term        |     int       | Возвращает заданное значение в приложение                                                                                 |
|   Money       |     double    | Возвращает заданное значение в приложение                                                                                 |
|   Name        |     string    | Переопределяемое свойство. Возвращает установленное значение **названия вклада** в приложение (берется из библиотеки)     |                                                                                                                                                          
#### 1.5) Методы

|         Название           |  Тип данных   |               Параметры                    |                      Ограничения, смысл                                       |
| -------------------------- | ------------- | ------------------------------------------ | ----------------------------------------------------------------------------  |
|   Persent                  |     double    | -                                           |  Метод определяет процент вклада, в зависимости от размера суммы пользователя
|   CalculateThePersentage   |     double    |  -                                          |  Метод начисляет процент на сумму вклада
|   PlusSum                  |     double    | В качестве параметра передается сумма, которую нужно начислить |  Метод начисляет сумму на вклад пользователя
|   MinusSum                 |     double    | В качестве параметра передается сумма, которую нужно снять |  Метод снимает сумму с вклада пользователя

### 2.1) Имя – Special
#### 2.2) Что за класс – наследуемый класс
#### 2.3) Параметры конструктора – конструктор без параметров
#### 2.4) Свойства

|   Название    |   Тип данных  |                   Назначение                                                                                              |
| ------------- | ------------- | ------------------------------------------------------------------------------------------------------------------------  |
|   MoneyB      |     double    | Возвращает заданное значение **размера не снимаемого остатка** в приложение, Добавляет значение в список                  |
|   Name        |     string    | Переопределенный метод (override). Возвращает установленное значение названия вклада в приложение (берется из библиотеки) |
                                                                                                                                                            
#### 2.5) Методы

|   Название   |  Тип данных   |               Параметры                |                      Ограничения, смысл                                       |
| ------------ | ------------- | -------------------------------------- | ----------------------------------------------------------------------------  |
|   MinusSum   |    double     | Передается сумма, которую нужно снять  | Переопределенный метод. Метод позволяет пользователю снимать деньги с вклада до тех пор, пока на вкладе не останется сумма, равная неснижаемому остатку                                 
|   MinimumB   |    double     |     -                                  |  Метод возвращает **минимальное значение не снимаемого остатка** из списка    |

### 3.1) Имя – Prime
#### 3.2) Что за класс – наследуемый класс
#### 3.3) Параметры конструктора – конструктор без параметров
#### 3.4) Свойства

|   Название    |   Тип данных  |                   Назначение                                                                                              |
| ------------- | ------------- | ------------------------------------------------------------------------------------------------------------------------  |
|   Cashback    |     double    |    Возвращает заданное значение **кэшбека**                                                                               |
|   Name        |     string    |    Переопределенное метод. Возвращает установленное значение **названия вклада** в приложение (берется из библиотеки)     |

#### 3.5) Методы

|         Название           |  Тип данных   |               Параметры                    |                      Ограничения, смысл                                       |
| -------------------------- | ------------- | ------------------------------------------ | ----------------------------------------------------------------------------  |
|   Return_Cashback          |     double    | -                                          |  Метод возвращает процент при снятии денег (кэшбек)                           |
|   MinusSum                 |     double    | Передается сумма, которую нужно снять      |  Переопределенный метод. При снятии денег с вклада возвращается кэшбек        |
|   MinimumCash              |     double    | -                                          |  Метод возвращает **минимальное значение кэшбека** из списка


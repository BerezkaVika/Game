[![Typing SVG](https://readme-typing-svg.herokuapp.com?font=Fira+Code&size=24&pause=1000&width=435&lines=Сценарий+игры)](https://git.io/typing-svg)

В начале игры на главном экране у пользователя есть возможность выбрать один объект, на котором будет базироваться вся игра. (замок, форт, монастырь). 
Далее пользователь вводит необходимые данные об объекте.
## Вводимая информация:

|   Имя поля и его тип данных                 |   Замок                                            | Форт               |       Монастырь                                        
| ------------------------------------------- | ---------------------------------------------------| -------------------|---------------------------------------------------- |
|   Основные поля (есть у всех трех классов)  |  Имя (string), Сумма (double), Заработок (double)  |                    |                                                     |
|   Дополнительные поля                       |  -                                                 | Кол-во орудий (int)|  Кол-во монахов (int)                               |

### Правила ввода данных:
1.	Вводите в поля данные корректного типа. (См в таблице выше) 
2.	Все числовые вводимые параметры должны быть неотрицательными.
3.	Не оставляйте поля пустыми

### Суть игры:
Вы владеете объектом. На его содержание требуются средства, но здания в замке приносят доход владельцу. Уровень заработка и затрат Вы определяете самостоятельно.
От введенных данных, будет зависеть состояние объекта – убыточное или прибыльное по истечение суток. Дополнительные поля Форта и Монастыря имеют влияние на подсчет расхода. 

Объект также обладает банком, в котором пользователь может открыть n-ное кол-во вкладов разных типов и работать с ними. Однотипные вклады он может объединять, и после также работать с ними. Работа с вкладами подразумевает: положить деньги на вклад, снять деньги, начислить процент.

## Работа с банком:

|   Имя поля и его тип данных                 |   Базовый вклад                                                                  | Особенный вклад    |       Вклад Премьер        |         
| ------------------------------------------- | ---------------------------------------------------------------------------------| -------------------|--------------------------- |
|   Основные поля (есть у всех трех классов)  |  Сумма (double), Название вклада(string), Срок (int), Процент по вкладу (double) |  -                 |  -                         |
|   Дополнительные поля                       | -                                                                | Размер не снимаемой суммы (double) | Размер кэшбека (double)    |

### Правила ввода данных:
1.	Вводите в поля данные корректного типа. (См в таблице выше) 
2.	Все числовые вводимые параметры должны быть неотрицательными.

### Принцип взаимодействия денежной суммы объекта и банка:
1.	Пользователь не может положить в банк сумму больше самой денежной суммы объекта.
2.	При открытии вклада сумма, положенная в банк, вычитается из общей суммы этого объекта.
3.	«Начислить» деньги на вклад – сумма также вычитается из общей суммы объекта.
4.	«Снять» деньги с вклада – сумма с вклада начисляется на общую сумму объекта.
5.	«Начислить процент» - на сумму вклада начисляется процент – зависит от установленного срока.
6.	Деньги, находящиеся в банке, не могут идти на содержание объекта


Созданный пользователем вклад можно добавить в список вкладов, после чего объединить однотипные. Работать с однотипными вкладами можно в окошке «Объединенные вклады» по тому же принципу, что и при создании вкладов (сохраняются все те же принципы работы с вкладом, описанные выше.)

##

[![Typing SVG](https://readme-typing-svg.herokuapp.com?font=Fira+Code&size=24&pause=1000&width=435&lines=Описание+библиотеки+классов)](https://git.io/typing-svg)
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
![image](https://github.com/BerezkaVika/Game/blob/main/Screenshots/library_1.png)


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


# Army Management Application

Это приложение позволяет управлять армией, состоящей из различных типов юнитов, таких как воины, лучники и маги. Пользователи могут добавлять, нанимать и увольнять юнитов, а также проверять состав армии и её характеристики. Приложение использует валидацию ввода данных с помощью регулярных выражений для обеспечения корректности ввода.

## Описание функциональности

- **Просмотр юнитов**: Пользователи могут видеть список доступных юнитов, их характеристики, стоимость и количество.
- **Найм и увольнение юнитов**: В приложении можно нанимать юнитов (сумма затрат списывается с золота игрока) и увольнять их (денежные средства возвращаются).
- **Добавление новых юнитов**: Пользователи могут добавлять новые юниты с заданными характеристиками.
- **Сохранение и сброс состояния**: Возможность сохранить состав армии и сбросить все изменения.

## Основные функции

1. **Интерфейс пользователя**:
    - **DataGrid** для отображения списка юнитов.
    - Возможность добавлять юнитов через окно с формой.
    - Возможность нанять или уволить юнита с помощью кнопок.
    - Показывает текущее количество золота.

2. **Валидация данных**:
    - Проверка корректности ввода с использованием регулярных выражений.
    - Проверка на корректность числовых значений (положительные целые числа и вещественные числа с двумя знаками после запятой).

3. **Функции для взаимодействия с армией**:
    - **Нанять юнитов** — добавление юнитов в армию при достаточном количестве золота.
    - **Уволить юнитов** — удаление юнитов из армии и возврат золота.
    - **Сохранение армии** — сохранение текущего состояния армии и её состава.

## Использование

1. **Главное окно**:
    - На главном экране отображается текущее количество золота игрока.
    - Список юнитов (с возможностью нанять или уволить).
    - Для каждого юнита отображается:
        - Название
        - Тип (Melee, Ranged, Magic)
        - Сила атаки
        - Стоимость
        - Доступное количество
        - Нанятое количество

2. **Добавление юнита**:
    - Нажмите **Добавить юнита** для открытия окна с формой.
    - Введите название, тип, силу атаки, стоимость и количество доступных юнитов.
    - Введите корректные данные, так как приложение будет проверять ввод с помощью регулярных выражений.

3. **Нанимать и увольнять юнитов**:
    - Для найма: выберите юнита и нажмите кнопку **+**.
    - Для увольнения: выберите юнита и нажмите кнопку **-**.
    - Доступное количество юнитов и золото обновляются автоматически.

4. **Сохранение состояния**:
    - Нажмите **Сохранить**, чтобы сохранить текущий состав армии.
    - Нажмите **Сбросить**, чтобы сбросить все изменения и вернуться к исходному состоянию.

## Пример работы

### Добавление юнита:
- Введите название, тип (например, "Лучник"), атаку, стоимость и количество доступных юнитов.
- Приложение проверит, чтобы данные были корректными (например, цена с двумя знаками после запятой для стоимости).
- После успешной проверки юнит будет добавлен в список.

### Найм юнита:
- Выберите юнита из списка и нажмите на кнопку **+**.
- Если у вас достаточно золота и есть доступные юниты, они будут наняты, а золото будет уменьшено.

### Увольнение юнита:
- Выберите нанятого юнита и нажмите **-**.
- Юнит будет уволен, и золото вернется.

## Структура проекта

- **MainWindow.xaml**: Основной интерфейс приложения.
- **MainWindow.xaml.cs**: Логика взаимодействия с юнитами и управлением армией.
- **AddUnitWindow.xaml**: Окно для добавления нового юнита.
- **AddUnitWindow.xaml.cs**: Логика добавления нового юнита и валидации ввода данных.
- **Unit.cs**: Модель данных для представления юнита.

# Corlib.NStar
<font size=20><b>Corlib.NStar</b></font> - стандартная библиотека фреймворка .NStar, изначально разрабатывавшаяся для языка под названием C# .NStar (а еще раньше сам язык сменил множество названий, пока не установилось это). Но теперь эта библиотека доступна для подключения к абсолютному большинству "нормальных" языков! ("Нормальных" - значит не эзотерических/игрушечных и не каких-то слишком упрощенных конструкторов.) Разумеется, в ней недоступны возможности, специфичные для языка, такие как практически полное отсутствие StackOverflow благодаря симуляции стека вызовов в куче или escape-последовательности &#92;! и &#92;q, но большинство возможностей реализуемы и в виде библиотеки для большинства языков. В библиотеку также полностью вошла старая библиотека BigCollections - запрос этого имени в GitHub перенаправляет сюда. Чтобы библиотека работала, необходимо:
<ol><li>В "Обозревателе решений" выделить основной проект и нажать "Показать все файлы".</li>
<li>Открыть файл <tt>obj\Debug\net6.0\&lt;ProjectName&gt;.GlobalUsings.g.cs</tt>.</li>
<li>Скопировать содержимое и вставить его в любой пользовательский файл (например, Program.cs), удалив строки <tt>global using global::System.Collections.Generic;</tt> и <tt>global using global::System.Linq;</tt>.</li>
<li>Если некоторые типы из этих пространств имен вам все же нужны (например, HashSet), добавьте в конец вставленного на предыдущем шаге блока <tt>global using G = global::System.Collections.Generic;</tt> и перед именами этих типов вставьте <tt>G.</tt>.</li>
<li>Открыть файл &lt;ProjectName&gt;.csproj и удалить строку <tt>&lt;ImplicitUsings&gt;enable&lt;/ImplicitUsings&gt;</tt>.</li>
<li>Если вам нужен класс String, его нужно подключать особым способом - в конец списка GlobalUsings добавьте следующую строку: <tt>global using String = Corlib.NStar.String;</tt>.<br></li></ol>
Примечание: точность всех названий до бита не гарантируется. Но вы же человек, а не машина? На всякий случай проверяйте другие названия, похожие на вышеуказанные.<br><br>
Библиотека содержит несколько типов коллекций - List, BitList, Dictionary и прочие. Классы похожи на соответствующие классы mscorlib, но в некоторых случаях более оптимизированы (а в некоторых - наоборот, это же The Fastest .NET Yet!). Оригинал взят с https://referencesource.microsoft.com/. В частности, оптимизированы для устранения лишних проходов по коллекциям методы List.Insert, List.InsertRange, SortedDictionary.Add, SortedDictionary.Search и прочие. Исправлен баг, вследствие которого InsertRange с IEnumerable, но не ICollection занимало квадратичное время.<br>
Возможно, не всем понятно назначение класса <b>Chain</b>, так как у него нет аналогов в mscorlib. Он представляет собой цепь целых чисел, которая не хранится полностью, а только начало и длина. По ней можно даже итерироваться, не загружая в память полностью. Она создается полностью только при преобразовании в другой тип.<br><br>
Отдельного внимания заслуживает файл <b>RedStarLinq.cs</b>. Он содержит авторский аналог LINQ, в котором существенно больше методов и разных их реализаций, чем в классическом LINQ. Его код похож на автогенерируемый и по факту на 80% таким является. 19% - код, скопированный с автогенерирумемого, в котором произведены некоторые замены, и лишь 1% написан вручную.<br>
Назначение большинства методов понятно из названия. Названия сделаны более понятными непосвященному, чем в классическом LINQ, где они взяты из SQL, который точно мало кому понятен. Методы, которые мне не удалось реализовать, просто вызывают методы классического LINQ (но тоже иногда переименованы).<br>
В отличие от классического LINQ, реализованные мной методы возвращают List, а не IEnumerable (кроме преобразующих в конкретный тип коллекции), вследствие чего следующий метод может выполняться существенно быстрее, чем в классическом LINQ. (А может и существенно медленнее!) А некоторые методы вообще выполняются с другой асимптотикой - например, Count() для строки.<br>
Все методы, у которых есть функция конверсии, поставляются с двумя ее версиями - только от элементов и от элементов и номера. Даже вызывающие классический LINQ.<br><br>
Вот описание методов, назначение которых может быть непонятно:<br>
Any без параметров (только последовательность) - проверяет, что последовательность не пуста.<br>
CopyDoubleList, CopyTripleList - копирует двумерный или трехмерный список полностью, а не только ссылки на (n - 1)-мерные списки, как new List&lt;T&gt;().<br>
Fill - заполняет список одинаковыми значениями или функциями от номера элемента, позволяя не вычислять каждый раз пустой элемент. К сожалению, если вы укажете в elem объект ссылочного типа, список будет заполнен ссылками на один и тот же объект. Если кто знает, как исправить эту проблему - пишите в обсуждении. Для временного обхода используйте вторую функцию с _ вместо номера.<br>
FindXIndexes, IndexesOfX - возвращает сразу ВСЕ индексы, в которых находится нужный элемент, а не только первый или последний.<br>
Median - сортирует последовательность и возвращает значение, находящееся в середине.<br>
Max/Mean/Median/Min(params &lt;type&gt;[] source) - позволяет вычислить нужную функцию, передав ей параметры один за другим, а не в виде коллекции - как Math.Max и Math.Min, только для произвольного числа параметров (но не меньше трех, так как для одного элемента функция тривиальна, а при двух функция существенно медленнее функции из Math). Рекомендуется указывать имя класса хотя бы одной буквой, так как иначе для двух элементов возникнет конфликт методов.<br>
OfType - возвращает ТОЛЬКО элементы требуемого типа, игнорируя остальные. Этот метод работает с нетипизированным IEnumerable.<br>
RepresentIntoNumbers - присваивает элементам последовательности номера, одинаковые для равных элементов и разные - для отличающихся, и возвращает список этих номеров. Нумерация начинается с нуля.<br>
SetInnerType - приводит каждый элемент последовательности к нужному типу с помощью либо оператора явного приведения, либо пользовательской функции. Может выбросить InvalidCastException. Этот метод работает с нетипизированным IEnumerable.<br>
ToArray поддерживает реализации как без параметров (прямой аналог метода классического LINQ), так и с параметрами - опять же для экономии количества проходов по последовательности. Еще больше самых разных реализаций доступно в методе ToDictionary.<br>
TryGetLengthEasily - пробует получить количество элементов без полного перебора коллекции. В отличие от метода классического LINQ, возвращает true для существенно большего множества типов. Этот метод работает как с типизированным, так и с нетипизированным IEnumerable.<br>
Wrap и TryWrap - позволяют избежать как лишних действий, так и лишней строки кода в случае, когда результат вычисления очередного LINQ-метода используется в следующем несколько раз. По сути ничего функционального не делают, а только кэшируют поданную им последовательность, позволяя написать x вместо громоздкого выражения, и вызывают внутреннюю функцию.<br><br>
Тесты показали, что при первом запуске данные методы могут быть даже медленнее классических, становясь быстрее лишь после "разогрева" (и то только те, которые предназначены быть быстрыми).<br>
Метод JoinIntoSingle необходимо вызывать, либо предварительно приведя средний тип двумерной коллекции к List, либо указывая в угловых скобках сначала этот средний тип вместе со внутренним, а затем целевой тип - если хоть один не указать, метод не работает!<br>
Благодаря неоценимому участию Элд Хасп класс BitList способен копировать фрагменты своих экземпляров существенно быстрее, чем бит за битом. Сам я с этим бы не справился. <b>Элд Хасп</b>, еще раз благодарю вас, вы сделали очень много хорошего!<br><br>
Также списки (в том числе BitList) поддерживают несколько методов, которых нет в классических реализациях:<br>
GetRange, принимающий именно Range, а не index и count, а также индексатор такой же формы.<br>
SetRange - записывает коллекцию элементов "поверх" того, что было в списке, начиная с index.<br>
ReplaceRange - по форме удаляет диапазон и вставляет в место его бывшего начала нужную коллекцию, а по содержанию общие индексы копирует, а только отличающиеся удаляет или вставляет. Метод не проверял, могут быть ошибки.<br>
Contains, IndexOf, LastIndexOf с поиском последовательности.<br>
ContainsAny, IndexOfAny, LastIndexOfAny - поиск в исходном списке любого из элементов целевой последовательности.<br>
ContainsAnyExcluding, IndexOfAnyExcluding, LastIndexOfAnyExcluding - поиск в исходном списке любого из элементов, отсутствующих в целевой последовательности.<br>
GetBefore, GetBeforeLast - возвращает фрагмент исходного списка перед целевой последовательностью, либо, если ее нет в исходном списке, весь этот список.<br>
GetAfter, GetAfterLast - возвращает фрагмент исходного списка после целевой последовательности, либо, если ее нет в исходном списке, пустую коллекцию.<br>
StartsWith, EndsWith - проверяет, начинается ли или заканчивается ли исходный список на целевую последовательность.<br>
Также возможны ошибки и в других не самых популярных классах и методах, так как протестировать всё и во всех случаях невозможно.<br><br>
<b>Обновление 1.</b> Добавилось огромное количество новых методов для работы с переменными типов Span&lt;T&gt; и ReadOnlySpan&lt;T&gt;, которые по неизвестным мне и не зависящим от меня причинам не наследуются от IEnumerable&lt;T&gt;. Число строк перешагнуло "круглую" отметку в 50k.<br><br>
<b>Обновление 2.</b> Методы нахождения экстремумов теперь являются non-nullable, возвращая 0 в случае пустой коллекции. Исправлена критическая ошибка в поведении словаря, из-за которой функция TryGetValue возвращала false, а прямое обращение по ключу могло вызвать исключение.<br><br>
<b>Обновление 3.</b> Добавлен небольшой и легкий в создании, но иногда нужный класс <b>LimitedQueue</b>, представляющий собой очередь ограниченной емкости, по достижению которой при попытке добавить еще один элемент - элементы из начала очереди будут удаляться.<br><br>
<b>Обновление 4.</b> Большое обновление, в ходе которого: старая библиотека BigCollections была объединена со стандартной библиотекой языка C# .NStar, и результат объединения стал называться Corlib .NStar; добавилась новая категория коллекций - множества, пока что только в виде всего одного конкретного класса HashSet&lt;T&gt;, а также абстрактного класса SetBase&lt;T, TCertain&gt;; в отличие от множеств, созданных Microsoft, множества от Red-Star-Soft могут работать не только как множества, но и как списки: их элементы имеют индексы, и для них можно вызвать большинство методов, которые можно вызвать для списков; переименованы некоторые методы и свойства, ключевое из которых - Count в Length - благодаря тому, что метод Count реализован в базовом интерфейсе явно, ни в одной коллекции от Red-Star-Soft свойства Count нет (разве что в какой-то забыл убрать); экспериментальные функции теперь выбрасывают исключение ExperimentalException, которое не прерывает работу программы, а служит только для оповещения - нажмите F5 для продолжения; модификатор доступа у непубличных членов списков был заменен с protected на private protected, чтобы их нельзя было переопределить вне нашей библиотеки; добавлен класс String, в котором конкатенация строк в цикле выполняется существенно быстрее, чем в строке от Microsoft, при этом строка от Microsoft неявно преобразуется в нашу, а ToString() выполняет обратное преобразование; наконец, во все типы списков добавлено множество новых методов: Equals с индексом (проверяется, равен ли диапазон списка какой-либо последовательности, не копируя этот диапазон) и основанные на нем (Last)IndexOf с последовательностью, GetBefore/After(Last), GetBeforeSetAfter(Last) и Starts/EndsWith, а также (Last)IndexOfAny и (Last)IndexOfAnyExcluding. Хронология изменений не соблюдена.<br><br>
<b>Обновление 5.</b> Corlib.NStar достигла "чугунного" уровня! Добавлен новый оптимизированный класс - ParallelHashSet&lt;T&gt;, в котором можно добавлять и удалять элементы параллельно (но либо добавлять, либо удалять, иначе могут быть ошибки!), и большинство стандартных методов уже делают это. Кроме того, как в новом классе, так теперь и в добавленном немного раньше HashSet&lt;T&gt;, хэш-коды и "корзины" (buckets, hashCode, next и freeList) теперь хранятся побитово инвертированными, что позволяет оптимизировать еще больше, так как в эти разнообразные "корзины" не нужно при инициализации и при каждом расширении записывать -1, а сама операция ~ занимает мизер времени. Тесты показали, что добавление 10<sup>8</sup> целых чисел, среди которых 65536 уникальных, в ParallelHashSet&lt;T&gt; при 4 потоках может быть до 32% быстрее, чем в System.Collections.Generic.HashSet&lt;T&gt;.<br><br>
<b>Обновление 6.</b> OptimizedLinq переименован в RedStarLinq, в котором максимально уменьшено количество конструирований новых списков, в том числе с помощью перебора последовательностей не через <tt>foreach</tt>, а напрямую через <tt>IEnumerator</tt>; в ParallelHashSet&lt;T&gt; устранен <tt>Parallel.ForEach</tt>, остался только <tt>Parallel.For</tt>; некоторые методы расширения теперь могут выполняться параллельно.<br><br>
<b>Обновление 7.</b> Добавлена новая категория коллекций - хэш-списки, которые могут содержать одинаковые элементы и искать элемент как по хэшам, так и линейным поиском, в том числе с возможностью автоматически определить более оптимальный вариант.<br><br>
<b>Обновление 8.</b> Важный патч, в котором существенно улучшена стабильность BitList, теперь вероятность ошибки составляет примерно 0.1%, и добавлен комплексный unit-тест с 1000 (псевдо)случайных итераций для предотвращения подобных поломок в будущем. Теперь, надеюсь, созданный в соавторстве с <b>Элд Хасп</b> метод копирования фрагментов списка бит работает полноценно! Хотя, конечно, на 100% гарантировать это нельзя никогда.<br><br>
<b>Обновление 9.</b> Добавлено множество на основе дерева, которое работает медленнее хэш-множеств, потребляет больше памяти, но всегда является отсортированным. А также TreeHashSet&lt;T&gt; - особая разновидность хэш-множества, в котором всегда корректные индексы, элементы добавляются и удаляются за O(logn), а поиск занимает Õ(1) - все благодаря внутреннему множеству-дереву удаленных элементов.<br><br>
<b>Обновление 10.</b> Corlib.NStar достигла "алюминиевого" уровня! Некоторые коллекции были переименованы, в частности, хэш-множества теперь называются FastDelHashSet&lt;T&gt; (с фейковыми индексами) и ListHashSet&lt;T&gt; (с медленным удалением), а хэш-списки - FastDelHashList&lt;T&gt; и просто HashList&lt;T&gt;, соответственно. Список бит теперь основан только на указателях, а не на массивах, благодаря чему создается меньше мусора, но никогда нельзя забывать после того, как список бит уже не нужен, вызвать метод Dispose().<br><br>
<b>Обновление 11.</b> Во все типы списков и множеств в Corlib.NStar наконец добавлены методы для замены элементов или целых блоков, как в строках от Microsoft. Хотя, конечно, еще многие их функции в нашей строке будут реализованы неизвестно когда...<br><br>
<b>Обновление 12.</b> Добавлены суммирующее множество (элементы имеют ключи, по которым отсортированы, и значения, организованные так, что легко посчитать их сумму от начала до любого заданного ключа), и суммирующий список (почти то же самое, только вместо ключей используются индексы). Все старые верифицируемые методы обычного списка, списка бит и нативного списка покрыты unit-тестами, благодаря чему эти классы, по сути, уже находятся на этапе беты.<br><br>
<b>Обновление 13.</b> Добавлены большой массив и большой массив бит - благодаря чему пройдена значительная часть пути к тому, для чего эта библиотека, собственно, и проектировалась - к большому списку, но создание его самого́ будет нетривиальной задачей - и зеркало - это что-то в стиле двунаправленного словаря, где ключ может быть значением, а значение - ключом, что можно было бы достичь с помощью двух симметричных друг другу словарей, обновляемых синхронно, но тогда все ключи и значения хранились бы по два раза, а в зеркале от Red-Star-Soft они хранятся по одному разу; с помощью индексатора можно получить или установить как значение по ключу, так и ключ по значению, но если они одного типа, возникнет ошибка из-за неоднозначности, и на этот случай в запасе есть методы GetValue(), SetValue(), GetKey() и SetKey(). Также, метод RedStarLinq Count() без параметров переименован в Length(), а старое название теперь принадлежит только методам подсчета количества элементов, соответствующих некоторому условию.<br><br>
<b>Обновление 14.</b> Новые классы - Slice&lt;T&gt; или срез - похож на Span&lt;T&gt;, но, в отличие от него, реализует интерфейс IEnumerable&lt;T&gt; - и Buffer&lt;T&gt; - коллекция фиксированной емкости, при превышении элементы удаляются из начала. Срез не наследуется от BaseList&lt;T, TCertain&gt;, вместо этого часть базового функционала выделена в еще более базовый класс BaseIndexable&lt;T, TCertain&gt;, от которого наследуются, кроме базового списка, все коллекции, в которых есть индексация, но которые нельзя изменять, в том числе и срез. RedStarLinq обновлен с учетом BaseIndexable&lt;T, TCertain&gt;, вследствие чего его длина превысила 70 тысяч строк. Также все индексируемые коллекции теперь имеют метод поэлементного сравнения двух коллекций, возвращающий индекс первого отличающегося элемента.<br><br>
<b>Обновление 15.</b> Corlib.NStar достигла "бронзового" уровня! Mpir.NET был переписан под .NET 7, вследствие чего компилятор больше не генерирует по надоедливому предупреждению, выдаваемому в тексте каждой сборки и постоянно "висящему" в списке ошибок, для каждого проекта в решении, ссылающегося на Corlib.NStar! Это был ПРОРЫВ!!! Впрочем, переписана только обертка, сама библиотека (GMP/Mpir) осталась в старой версии, и вряд ли когда-то я смогу сам написать обертку на новую. Тип большого числа теперь является не классом, а структурой, а его имя соответствует рекомендациям для языка C# - не <b>m</b>pz<b>_t</b>, а <b>M</b>pz<b>T</b>. Кроме того, обновлен комплексный тест для ParallelHashSet&lt;T&gt; и написаны тест конструирования и тест на "вылет" для него же, а для корректности теста на "вылет" добавлены Debug.Assert после добавления и удаления элемента. Благодаря всему этому самое быстрое из существующих хэш-множество наконец достигло версии Alpha!<br><br>
<b>Обновление 16.</b> Все списки в Corlib.NStar получили новые варианты метода Replace() - можно заменить не только один диапазон на один, но и все пары в целом словаре! Поддерживаются словари из элемента в элемент, из элемента в диапазон, из пары элементов (задается кортежом, List&lt;T&gt; и NList&lt;T&gt; легко преобразуются в кортеж) в диапазон и из триады элементов в диапазон. Замена по словарю из диапазона в диапазон в разработке.<br><br>
<b>Обновление 17.</b> Добавлены экстенты Shuffle() и NShuffle() для перемешивания любой последовательности (по факту создают новую последовательность, являющуюся случайным порядком старой, так как ясно, что напрямую произвольный IEnumerable (например, цепь или коллекцию ключей словаря, которая бессмысленна без оригинального словаря) перемешать нельзя), а также ToParallelHashSet() для нашего супер-быстрого удаления дубликатов в последовательности).<br><br>
<b>Обновление 18.</b> Добавлены экстенты AllEqual(), AllUnique(), Product() и NGroup().<br><br>
<b>Обновление 19.</b> Исправлены основные экстенты RedStarLinq, потреблявшие неадекватное количество памяти. Наконец осуществлена мечта, с которой начиналась библиотека BigCollections - <b>доведены до рабочего состояния классы BigList&ltT&gt; и BigBitList!</b> Они поддерживают добавление элемента или диапазона в конец, удаление элемента или диапазона из любого места, удаление от некоторого индекса и до конца, обрезку избытка емкости, копирование диапазона, в том числе в список с другой размерностью внутреннего дерева (а у него внутри дерево, так как создать массив длиной более 2 миллиардов элементов нельзя) и примерно 60 типов конструирования, но пока не поддерживает вставку в любое место (это в разработке). Есть ломающие изменения: из списка бит удален конструктор из нетипизированного IEnumerable, а из всех списков и множеств - метод Remove() с указанием только индекса как имеющий неоднозначное и вводящее в заблуждение название - взамен необходимо использовать Remove() с указанием диапазона, RemoveAt(), RemoveEnd() или RemoveValue().<br><br>
Payeer: P19926501<br>
Monero: 4AHvZX6BHNcZ6T2iCq4Ruu3nGXipEzjdyYPpvLGMqCzXartsMJoFBxRjXEeKRXDu96JCyYvvPunNnSMBeKYTS8iXBw9z6p3<br>
TRC20 (TRX, USDT etc.): TUKh42VHJNTSCmCdu5rnGo8fDotDK8rHA5<br>
Вопросы: adminATred-star-softDOTcom<br>

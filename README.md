# 4 lab
В рамках лабораторной работы подразумевается разработка системы, которая управляет
процессом создания бекапов. Для упрощения выполнения лабораторной, создавать
физически резервные копии указанных файлов не требуется. Достаточно будет создать
запись о том, что было сделано резервное копирование.

Информация о бекапе представлена в виде набора параметров: Id, CreationTime, BackupSize
и список точек восстановления.

Алгоритмы создания и хранения

Для создания бекапа указываются объекты: список файлов или папок. Должна быть
реализована возможность в последствии этот список редактировать - добавлять и удалять
объекты из списка объектов которые будут обрабатываться в алгоритме.
Система должна поддерживать несколько алгоритмов создания точек восстановления для
бекапа, а также возможность увеличивать их количество. Результатом работы алгоритма
является создание новой точки восстановления для указанного бекапа. Точка
восстановления хранит о себе информацию о том, какие объекты были в ней забекаплены.
В алгоритме должна быть возможность указать требуется ли создать полноценную точку
или только дельту с прошлого раза (т.е. инкремент).
Требуется реализовать как минимум два алгоритма хранения:
Алгоритм раздельного хранения — файлы копируются в специальную папку и
хранятся там раздельно.
Алгоритм общего хранения — все указанные в бекапе объекты складываются в один
архив.


Алгоритмы очистки точек

Помимо создания, нужно контролировать количество хранимых точек восстановления.
Чтобы не допускать накопления большого количества старых и неактуальных точек,
требуется реализовать механизмы их очистки — они должны контролировать, чтобы
цепочка точек восстановления не выходила за допустимый лимит. В рамках лабораторной
подразумеваются такие типы лимитов:
По количеству - ограничивает длину цепочки точек восстановления (храним
последние N точек)
По дате - ограничивает насколько старые точки будут хранится (храним все точки,
которые были сделаны не позднее указанной даты)
По размеру - ограничивает суммарный размер, занимаемый бекапом (храним все
последние бекапы, суммарный размер которых не превышает лимит)

Гибрид - возможность комбинировать лимиты. Пользователь может указывать, как
комбинировать:
нужно удалить точку, если вышла за хотя бы один установленный лимит
нужно удалить точку, если вышла за все установленные лимиты
Например, пользователь выбирает гибрид алгоритмов "по количеству" и "по дате".
Если по одному из алгоритмов необходимо оставить 3 точки, а по другому — 5, то
выбирается количество точек в соответствии с параметром, указанном при создании
"гибрида" (использовать максимальное или минимальное значение отобранных
точек).
Алгоритм должен учитывать то, что инкрементальные точки не должны остаться без
точки, от которой взята дельта. В случае, если пришлось оставить точек больше, чем
планировалось, результат выполнения алгоритма должен вернуть соответствующее
предупреждение.
// See https://aka.ms/new-console-template for more information

using DmitryKublashviliHabrLinqIntoKeyhole;

InitialExample();
MyWhereExample();
MyWhereUnwrappedExample();
MyWhereUnwrappedAndCustomFirstLastExample();

void InitialExample()
{
    var linqCounter = 0;
    byte[] array = {0, 0, 1, 0, 1};

    var bytes = array.Where(x =>
    {
        linqCounter++;
        return x > 0;
    });

    var t = bytes.First() == bytes.Last();
    
    //  Getting 8 in linqCounter. Why?
    Console.WriteLine(linqCounter);
}

void MyWhereExample()
{
    var linqCounter = 0;
    byte[] array = {0, 0, 1, 0, 1};

    var bytes = array.MyWhere(x =>
    {
        linqCounter++;
        return x > 0;
    });

    var t = bytes.First() == bytes.Last();
    
    //  Still getting 8 in linqCounter. Why?
    Console.WriteLine(linqCounter);
}

void MyWhereUnwrappedExample()
{
    var linqCounter = 0;
    byte[] array = {0, 0, 1, 0, 1};

    var bytes = array.MyWhereUnwrap(x =>
    {
        linqCounter++;
        return x > 0;
    });

    var t = bytes.First() == bytes.Last();
    
    //  Still getting 8 in linqCounter. Why?
    Console.WriteLine(linqCounter);
}

void MyWhereUnwrappedAndCustomFirstLastExample()
{
    var linqCounter = 0;
    byte[] array = {0, 0, 1, 0, 2};
        //1
    var bytes = array.MyWhereUnwrap(x =>
    {
        linqCounter++;
        return x > 0;
    });
                //2                 //3
    var t = bytes.MyFirst() == bytes.MyLast();
    
    //  Still getting 8 in linqCounter. Why?
    Console.WriteLine(linqCounter);
    
    Console.WriteLine(bytes.MyFirst());
    Console.WriteLine(bytes.MyLast());
}

/*
    1 - We form a way of performing the action (request). 
        This is not yet the action itself, but only its definition.

    2 - The MyFirst() method calls an action (refers to our IEnumerable <T>),
        which is executed exactly until the moment the method needs this action,
        that is, until it finds one.
        There are two enumerators working here. The enumerator of the MyFirst()
        method expects an item to be supplied from the IEnumerable <T> bytes enumerator.
        This enumerator does MoveNext() 3 times, finds the first element (1) and gives it
        to the enumerator of the MyFirst () method, after which the MyFirst () method returns
        a value, completes and no longer needs the second enumerator.
        From this point on, the IEnumerable <T> bytes action from the point of view of its initiator
        (MyFirst ()) is terminated and the second enumerator receives its Dispose ().
        The counter at this step is incremented to 3.

    3 - The MyLast () method calls an action (refers to our IEnumerable <T>),
        which is executed exactly until this action is necessary for the method ...
        (we have already gone through something similar above) ... that is, until two are found ...
        There are also two enumerators working here. The enumerator of the MyLast () method 
        calls its MoveNext () two times (since only two elements match the predicate).
        The first time this will force the second enumerator to do MoveNext () 3 times before finding one.
        The counter is incremented from 3 to 6.

    On the second request of the first enumerator, the second enumerator will have to perform two more
    MoveNext () until it reaches from 3 array elements to 5 (to the end).
    Here the counter is incremented from 6 to 8.

    The magic in the debugger is due to the fact that whenever we try to see 
    the resulting values of IEnumerable <T> bytes by clicking on the ResultsView,
    we run the enumerator again and again, because the set does not exist as such,
    and in order to provide the results of the selection, we need to perform an ACTION ...
    This is the reason for the counter changes in the debugger.

    This aspect is also called deferred (or lazy) execution
    (although from the point of view of implementation, everything is performed
    here when prescribed by the code).*/
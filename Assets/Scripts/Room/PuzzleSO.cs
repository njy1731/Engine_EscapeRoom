//using system.collections;
//using system.collections.generic;
//using system;
//using unityengine;
//using unityengine.ui;

//[createassetmenu(filename ="new puzzle", menuname ="room/puzzles/new puzzle")]
//public class puzzleso : scriptableobject
//{
//    public list<puzzlenumber> puzzlenum = new list<puzzlenumber>();

//    public puzzlenumber[] randomnum(int length)
//    {
//        puzzlenumber[] puzzlenumbers = new puzzlenumber[length];
//        for (int i = 0; i < length; i++)
//        {
//            int id = unityengine.random.range(0, 10);
//            puzzlenumbers[i] = puzzlenum.find(x => x.id == id);
//        }

//        return puzzlenumbers;
//    }
//}

//public static class passwordgenerator
//{
//    public static int[] randomnumbers(int maxcount, int n)
//    {
//        int[] defaults = new int[maxcount];
//        int[] results = new int[n];

//        for (int i = 0; i < maxcount; ++i)
//        {
//            defaults[i] = i;
//        }

//        for (int i = 0; i < n; ++i)
//        {
//            int index = unityengine.random.range(0, maxcount);

//            results[i] = defaults[index];
//            defaults[index] = defaults[maxcount -1];

//            maxcount--;
//        }

//        return results;
//    }
//}
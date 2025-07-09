public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        //hypothesis: test for valid pairs of (), {}, and []'s
        //Input: (a == 3 or (b == 5 and c == 6))
        // result = true, é verdade porque o conteúdo é ignorado então fica (())
        //Input: (students]i].Grade > 80 and students[i].Grade < 90)
        // result = false, é falso porque o conteúdo é ignorado então fica (]][])
        //Input:(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))
        // result: false
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
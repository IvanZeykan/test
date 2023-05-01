public static int GetMeetingCount(int[] population, int desiredColor)
{
    int total = population.Sum();
    if (population[desiredColor] == total) // вже всі їжачки мають бажаний колір
    {
        return 0;
    }

    int[] current = new int[3]; // кількість їжачків кожного кольору на поточному етапі
    Array.Copy(population, current, 3);

    int meetingCount = 0; //кількість зустрічей
    while (true)
    {
        int[] next = new int[3]; // кількість їжачків кожного кольору на наступному етапі

        // зустрічаються два їжачки різних кольорів та змінюють свій колір на третій
        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 3; j++)
            {
                if (current[i] > 0 && current[j] > 0)
                {
                    int k = 3 - i - j; // індекс третього кольору
                    int change = Math.Min(current[i], current[j]); // кількість їжачків, які змінять колір
                    next[i] += change;
                    next[j] += change;
                    current[i] -= change;
                    current[j] -= change;
                    next[k] += change;
                }
            }
        }

        if (next[desiredColor] == total) // досягнуто бажаний колір
        {
            return meetingCount;
        }

        if (Array.Equals(next, current)) // не можна досягти бажаного коліру
        {
            return -1;
        }

        current = next;
        meetingCount++;
    }
}

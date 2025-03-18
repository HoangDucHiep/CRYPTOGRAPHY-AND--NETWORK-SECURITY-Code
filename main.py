def input_array(n):
    arr = []
    for i in range(n):
        arr.append(int(input()))
    return arr

def sum_array(*arr):
    sum = 0
    for i in arr:
        sum += i
    return sum

def is_asc_sorted(arr):
    for i in range(1, len(arr)):
        if arr[i] < arr[i - 1]:
            return False
    return True

if __name__ == '__main__':
    n = int(input())
    arr = input_array(n)
    print(sum_array(*arr))
    print(is_asc_sorted(arr))
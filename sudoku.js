function validSolution(board) {
  // перевірка рядків
  for (let i = 0; i < 9; i++) {
    if (!isValidSet(board[i])) {
      return false;
    }
  }

  // перевірка стовпців
  for (let i = 0; i < 9; i++) {
    let column = [];
    for (let j = 0; j < 9; j++) {
      column.push(board[j][i]);
    }
    if (!isValidSet(column)) {
      return false;
    }
  }

  // перевірка блоків
  for (let i = 0; i < 9; i += 3) {
    for (let j = 0; j < 9; j += 3) {
      let block = [];
      for (let k = i; k < i + 3; k++) {
        for (let l = j; l < j + 3; l++) {
          block.push(board[k][l]);
        }
      }
      if (!isValidSet(block)) {
        return false;
      }
    }
  }

  return true;
}

// допоміжна функція для перевірки, чи містить масив коректний набір чисел
function isValidSet(set) {
  // видаляємо всі нулі
  set = set.filter((n) => n !== 0);
  // перевіряємо чи не містить набір дублів
  return new Set(set).size === set.length && Math.max(...set) === 9;
}
const board1 = [
  [5, 3, 4, 6, 7, 8, 9, 1, 2],
  [6, 7, 2, 1, 9, 5, 3, 4, 8],
  [1, 9, 8, 3, 4, 2, 5, 6, 7],
  [8, 5, 9, 7, 6, 1, 4, 2, 3],
  [4, 2, 6, 8, 5, 3, 7, 9, 1],
  [7, 1, 3, 9, 2, 4, 8, 5, 6],
  [9, 6, 1, 5, 3, 7, 2, 8, 4],
  [2, 8, 7, 4, 1, 9, 6, 3, 5],
  [3, 4, 5, 2, 8, 6, 1, 7, 9],
];

console.log(validSolution(board1));

const board2 =[
   [5, 3, 4, 6, 7, 8, 9, 1, 2],
   [6, 7, 2, 1, 9, 0, 3, 4, 8],
   [1, 7, 8, 3, 4, 2, 5, 6, 0],
   [8, 5, 9, 7, 6, 1, 0, 2, 0],
   [4, 2, 6, 8, 5, 3, 7, 9, 1],
   [7, 1, 3, 9, 2, 4, 8, 5, 6],
   [9, 0, 1, 5, 3, 7, 2, 1, 4],
   [2, 8, 7, 4, 1, 9, 6, 3, 5],
   [3, 2, 0, 4, 8, 5, 1, 7, 9],
 ];
console.log(validSolution(board2));
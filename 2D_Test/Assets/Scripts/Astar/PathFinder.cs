using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Tilemap floorTileMap; //탐색할 바닥 타일맵 (벽 X)
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    [SerializeField] Color openColor;   //탐색 중인 타일 색상
    [SerializeField] Color closedColor; //탐색 완료된 타일 색상

    [SerializeField] List<Vector2Int> path;

    private void Start()
    {
        Vector2Int start = new Vector2Int((int)startPos.position.x, (int)startPos.position.y);
        Vector2Int end = new Vector2Int((int)endPos.position.x, (int)endPos.position.y);

        StartCoroutine(AStarCoroutine(start, end));

        //bool success = AStar(start, end, out path);

        //if (success)
        //{
        //    Debug.Log("경로 탐색 성공");
        //}
        //else
        //{
        //    Debug.Log("경로 탐색 실패");
        //}
    }

    private void Update()
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            Vector3 from = new Vector3(path[i].x, path[i].y, 0);
            Vector3 to = new Vector3(path[i + 1].x, path[i + 1].y, 0);
            Debug.DrawLine(from, to);
        }
    }

    static Vector2Int[] direction =
    {
        new Vector2Int(0, +1), //상
        new Vector2Int(0, -1), //하
        new Vector2Int(-1, 0), //좌
        new Vector2Int(+1, 0)  //우
    };

    private IEnumerator AStarCoroutine(Vector2Int start, Vector2Int end)
    {
        //0. 사전 세팅
        List<ASNode> openList = new List<ASNode>(); //탐색할 정점 후보들을 보관
        Dictionary<Vector2Int, bool> closeSet = new Dictionary<Vector2Int, bool>(); //탐색을 완료한 정점들을 보관
        path = new List<Vector2Int>(); //경로들을 보관할 리스트

        //처음으로 탐색할 정점을 openList에 추가
        openList.Add(new ASNode(start, null, 0, Heuristic(start, end)));

        while (openList.Count > 0 /*더이상 탐색할 정점이 없을 때까지*/)
        {
            //1. 다음으로 탐색할 정점 선택하기 (F가 가장 낮은, F가 같다면 H가 가장 낮은 것을 선택)
            ASNode nextNode = NextNode(openList);

            //2. 선택한 정점을 탐색했다고 표시
            openList.Remove(nextNode); //다음으로 탐색할 정점을 후보들 중에서 제거
            closeSet.Add(nextNode.pos, true); //탐색을 완료한 정점들에 추가

            //탐색이 완료된 타일 색깔 변경
            //참고 링크: https://m.blog.naver.com/cyh197/222193747948
            floorTileMap.SetTileFlags(new Vector3Int(nextNode.pos.x, nextNode.pos.y, 0), TileFlags.None);
            floorTileMap.SetColor(new Vector3Int(nextNode.pos.x, nextNode.pos.y, 0), closedColor);


            //3. 다음으로 탐색할 정점이 도착지인 경우 (경로 탐색을 성공 => path 반환하면서 종료)
            if (nextNode.pos == end)
            {
                ASNode current = nextNode;
                while (current != null)
                {
                    path.Add(current.pos);
                    current = current.parent;
                }
                path.Add(start);
                path.Reverse();
                yield break;
            }

            //4. 주변 정점들의 점수를 계산
            for (int i = 0; i <direction.Length; i++) //방향에 대한 반복
            {
                //점수를 넣어줄 위치
                Vector2Int pos = nextNode.pos + direction[i];

                //탐색하면 안되는 경우 제외
                //4-1. 이미 탐색한 정점이면
                if (closeSet.ContainsKey(pos))
                    continue;

                //4-2. 못가는 지형일 경우 (레이캐스트를 쏴서 닿는 지형이 있는지 없는지로 해도 됨)
                // tilemap.HasTile : 타일맵을 분석하거나,
                // Physics.Overlap : 충돌체 존재여부를 확인하거나,
                // Physics.Raycast : 중간에 장애물이 없거나
                if (Physics2D.OverlapCircle(pos, 0.4f) != null)
                    continue;

                //위에 두가지에 해당이 안 되면 갈 수 있는 지형
                //4-3. 점수 계산
                int g = nextNode.g + CostStraight;
                int h = Heuristic(pos, end);
                int f = g + h;

                //4-4. 정점의 점수 갱신이 필요한 경우
                ASNode findNode = FindNode(openList, pos);

                //점수가 없었던 경우
                if (findNode == null)
                {
                    openList.Add(new ASNode(pos, nextNode, g, h));

                    //탐색 중인 타일 색깔 변경
                    floorTileMap.SetTileFlags(new Vector3Int(pos.x, pos.y, 0), TileFlags.None);
                    floorTileMap.SetColor(new Vector3Int(pos.x, pos.y, 0), openColor);

                }

                //f가 더 작아지거나
                else if (findNode.f > f)
                {
                    findNode.f = f;
                    findNode.g = g;
                    findNode.h = h;
                    findNode.parent = nextNode;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }

        path = null;
    }

    public const int CostStraight = 10;
    public const int CostDiagonal = 14;

    //휴리스틱: 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로 탐색 효율이 결정됨
    public static int Heuristic(Vector2Int start, Vector2Int end)
    {
        int xSize = Mathf.Abs(start.x - end.x);
        int ySize = Mathf.Abs(start.y - end.y);

        //맨해튼 거리: 직선을 통해 이동하는 거리
        //return (xSize + ySize);

        //유클리스 거리: 대각선을 통해 이동하는 거리
        //return (int)Vector2Int.Distance(start, end);

        //타일맵 거리: 직선과 대각선을 통해 이동하는 거리
        int straightCount = Mathf.Abs(xSize - ySize);
        int diagonalCount = Mathf.Max(xSize, ySize) - straightCount;
        return CostStraight * straightCount + CostDiagonal * diagonalCount;
    }

    public static ASNode NextNode(List<ASNode> openList)
    {
        //F가 가장 낮은, F가 같다면 가장 낮은 H를 선택
        int curF = int.MaxValue;
        int curH = int.MaxValue;
        ASNode minNode = null;

        for (int i = 0; i < openList.Count; i++)
        {
            if (curF > openList[i].f)
            {
                curF = openList[i].f;
                curH = openList[i].h;
                minNode = openList[i];
            }
            else if(curF == openList[i].f && curH > openList[i].h)
            {
                curF = openList[i].f;
                curH = openList[i].h;
                minNode = openList[i];
            }
        }

        return minNode;
    }

    public static ASNode FindNode(List<ASNode> openList, Vector2Int pos)
    {
        for (int i = 0; i < openList.Count; i++)
        {
            if (openList[i].pos == pos)
            {
                return openList[i];
            }
        }   

        return null;
    }

}

public class ASNode
{
    public Vector2Int pos; //현재 정점의 위치
    public ASNode parent; //이 정점을 탐색할 정점

    public int f; //예상 최종 거리
    public int g; //걸린 거리
    public int h; //예상 남은 거리

    public ASNode(Vector2Int pos, ASNode parent, int g, int h)
    {
        this.pos = pos;
        this.parent = parent;
        this.f = g + h;
        this.g = g;
        this.h = h;
    }
}
using RestController.DTOs;
using RestController.DTOs.Enums;

namespace UT_RestController;

public class HandsControllerDataV1
{
    public static IEnumerable<object[]> Data_TestGetHandDetails()
    {
        yield return new object[]
        {
            1UL,
            new HandDTODetail()
            {
                Id = 1UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 9, 21),
                TakerScore = 210,
                TwentyOne = false,
                Excuse = true,
                Petit = PetitResultsDTO.Lost,
                Chelem = ChelemDTO.Unknown,
                Biddings = new List<BiddingPoigneeDTO>()
                {
                    new BiddingPoigneeDTO()
                    {
                        Biddings = BiddingsDTO.Petite,
                        Poignee = PoigneeDTO.None,
                        UserId = 1UL
                    },
                    new BiddingPoigneeDTO()
                    {
                        Biddings = BiddingsDTO.Opponent,
                        Poignee = PoigneeDTO.None,
                        UserId = 2UL
                    },
                    new BiddingPoigneeDTO()
                    {
                        Biddings = BiddingsDTO.Opponent,
                        Poignee = PoigneeDTO.None,
                        UserId = 3UL
                    }
                },
                GameId = 0UL
            }

        };
    }
}
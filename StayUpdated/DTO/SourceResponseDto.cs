using System.Collections.Generic;

namespace StayUpdated.DTO {
	public class SourceResponseDto {
		public string Status { get; set; }
		public List<SourceDto> Sources { get; set; }
	}
}
export abstract class BaseRepository {
  private protocol: string;
  private host: string;
  private api: string;

  protected get API_URL(): string {
    return `${this.protocol}${this.host}${this.api}${this.endpoint}`;
  }

  constructor(private endpoint: string) {
    this.protocol = 'http://';
    this.host = 'localhost:5000/';
    this.api = 'api/';
  }
}
